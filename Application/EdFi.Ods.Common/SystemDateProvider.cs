using System;

namespace EdFi.Ods.Common
{
    public class SystemDateProvider : ISystemDateProvider
    {
        public DateTime GetDate()
        {
            return DateTime.Today;
        }
    }
}
