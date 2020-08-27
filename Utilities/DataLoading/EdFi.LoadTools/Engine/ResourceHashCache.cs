// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using log4net;

namespace EdFi.LoadTools.Engine
{
    public class ResourceHashCache : IResourceHashCache, IDisposable
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(IResourceHashCache));

        private readonly BufferBlock<string> _deleteBuffer = new BufferBlock<string>();

        private readonly ActionBlock<string> _deleteFileBlock = new ActionBlock<string>(
            fileName =>
            {
                if (_log.IsDebugEnabled)
                {
                    _log.Debug($"Deleting file {fileName}");
                }

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            });

        private readonly Lazy<string> _filename;
        private readonly string _folder;
        private readonly ConcurrentDictionary<byte[], bool> _hashes;
        private readonly IHashProvider _hashProvider;
        private readonly IThrottleConfiguration _throttleConfiguration;

        private readonly ActionBlock<WriteBlock> _writeBlock = new ActionBlock<WriteBlock>(
            writeBlock =>
            {
                using (var stream = new FileStream(writeBlock.Filename, FileMode.Append))
                {
                    using (var writer = new BinaryWriter(stream))
                    {
                        if (_log.IsDebugEnabled)
                        {
                            _log.Debug($"Writing {writeBlock.Hash} to {writeBlock.Filename}");
                        }

                        writer.Write(writeBlock.Hash);
                    }
                }
            });

        private readonly BufferBlock<WriteBlock> _writeBuffer = new BufferBlock<WriteBlock>();

        public ResourceHashCache(IHashCacheConfiguration configuration, IThrottleConfiguration throttleConfiguration, IHashProvider hashProvider)
        {
            _throttleConfiguration = throttleConfiguration;
            _hashProvider = hashProvider;
            _folder = configuration.Folder;
            _hashes = new ConcurrentDictionary<byte[], bool>(new ByteArrayComparer());

            _writeBuffer.LinkTo(
                _writeBlock, new DataflowLinkOptions
                             {
                                 PropagateCompletion = true
                             });

            _deleteBuffer.LinkTo(
                _deleteFileBlock, new DataflowLinkOptions
                                  {
                                      PropagateCompletion = true
                                  });

            _filename = new Lazy<string>(
                () =>
                {
                    var timestamp = DateTime.UtcNow.Ticks;
                    return Path.ChangeExtension(Path.Combine(_folder, $"{timestamp}"), ".hash");
                });
        }

        public void Dispose()
        {
            _deleteFileBlock.Completion.Wait();

            _writeBuffer.Complete();
            _writeBlock.Completion.Wait();
        }

        IReadOnlyDictionary<byte[], bool> IResourceHashCache.Hashes => _hashes;

        public void Add(byte[] hash)
        {
            var copy = GetCopyOf(hash);
            _hashes.AddOrUpdate(copy, true, (k, v) => v);
            WriteToFile(copy);
        }

        public bool Exists(byte[] hash)
        {
            return _hashes.ContainsKey(hash);
        }

        public void Visited(byte[] hash)
        {
            var copy = GetCopyOf(hash);

            if (!_hashes.ContainsKey(hash))
            {
                return;
            }

            _hashes[copy] = true;
            WriteToFile(copy);
        }

        public void Load()
        {
            var hashFiles = Directory.GetFiles(_folder, "*.hash")
                                     .OrderByDescending(f => f)
                                     .ToList();

            // Note: since we are only getting the last known file, there may be other files that would need cleanup.
            // but we will keep the last 100 files from previous loads so we do not crash the operating system.
            CleanUpHashFiles(hashFiles.Skip(100));

            // We load the last known hash file
            string hashFile = hashFiles.FirstOrDefault();
            Load(hashFile);
        }

        private void CleanUpHashFiles(IEnumerable<string> files)
        {
            foreach (string file in files)
            {
                _deleteBuffer.Post(file);
            }

            _deleteBuffer.Complete();
            _deleteFileBlock.Complete();
        }

        private static byte[] GetCopyOf(byte[] bytearray)
        {
            var copy = new byte[bytearray.Length];
            Array.Copy(bytearray, copy, bytearray.Length);
            return copy;
        }

        private void WriteToFile(byte[] hash)
        {
            var block = new WriteBlock
                        {
                            Filename = _filename.Value, Hash = hash
                        };

            _writeBuffer.Post(block);
        }

        public void Load(string filename)
        {
            _hashes.Clear();

            if (string.IsNullOrEmpty(filename) || !File.Exists(filename))
            {
                return;
            }

            using (var fileStream = new FileStream(filename, FileMode.Open))
            {
                using (var bufferedStream = new BufferedStream(fileStream))
                {
                    using (var reader = new BinaryReader(bufferedStream))
                    {
                        var pos = 0L;
                        var length = reader.BaseStream.Length;

                        while (pos < length)
                        {
                            var bytes = reader.ReadBytes(_hashProvider.Bytes);
                            _hashes.AddOrUpdate(bytes, false, (k, v) => v);
                            pos += _hashProvider.Bytes;
                        }
                    }
                }
            }
        }

        public void Save(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.CreateNew))
            {
                using (var buffer = new BufferedStream(stream))
                {
                    using (var writer = new BinaryWriter(buffer))
                    {
                        foreach (var value in _hashes.Where(x => x.Value).Select(x => x.Key))
                        {
                            writer.Write(value);
                        }

                        writer.Flush();
                    }
                }
            }
        }

        private class ByteArrayComparer : IComparer<byte[]>, IEqualityComparer<byte[]>
        {
            public int Compare(byte[] x, byte[] y)
            {
                return x.Select((t, i) => t.CompareTo(y[i])).FirstOrDefault(result => result != 0);
            }

            public bool Equals(byte[] x, byte[] y) => Compare(x, y) == 0;

            public int GetHashCode(byte[] obj) => BitConverter.ToInt32(obj, 0);
        }

        private class WriteBlock
        {
            public string Filename { get; set; }

            public byte[] Hash { get; set; }
        }
    }
}
