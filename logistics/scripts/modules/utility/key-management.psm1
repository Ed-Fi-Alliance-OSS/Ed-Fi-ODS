# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

function New-AESKey() {
    <#
        .SYNOPSIS
            Generates and Base64-encodes a 256 bit key appropriate for use with AES encryption.

        .EXAMPLE
            Import-Module ./key-management.psm1
            New-AESKey
    #>

    $aes = [System.Security.Cryptography.Aes]::Create()
    $aes.KeySize = 256
    $aes.GenerateKey()
    [System.Convert]::ToBase64String($aes.Key)
}

Export-ModuleMember -Function New-AESKey