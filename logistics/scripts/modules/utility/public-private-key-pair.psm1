# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

<#
.SYNOPSIS
Generates a new RSA public/private key pair and outputs them in PEM format.

.DESCRIPTION
This function creates a 2048-bit RSA key pair and outputs the private and public keys in PEM format.

.EXAMPLE
Import-Module "./public-private-key-pair.psm1"
New-PublicPrivateKeyPair
This command generates a new 2048-bit RSA key pair.
#>
function New-PublicPrivateKeyPair {

	$rsa = [System.Security.Cryptography.RSA]::Create(2048)

	# Check if running on PowerShell 7+ (.NET Core/.NET 5+) which has PEM export methods
	$hasPemMethods = $rsa.GetType().GetMethod('ExportPkcs8PrivateKeyPem') -ne $null

	if ($hasPemMethods) {
		$privateKey = $rsa.ExportPkcs8PrivateKeyPem()
		$publicKey = $rsa.ExportSubjectPublicKeyInfoPem()
	}
	else {
		Write-Warning "Skipping signing key generation (PowerShell 7+ required for PEM export)"
		$privateKey = ""
		$publicKey = ""
	}

	$rsa.Dispose()

	return [PSCustomObject]@{
		PrivateKey = $privateKey
		PublicKey = $publicKey
	}
}

Export-ModuleMember -Function New-PublicPrivateKeyPair
