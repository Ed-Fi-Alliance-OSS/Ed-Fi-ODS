$rsa = [System.Security.Cryptography.RSA]::Create(2048)

# Export Private Key (for the API to sign tokens)
$privateKey = $rsa.ExportPkcs8PrivateKeyPem()
Write-Host "======= PRIVATE KEY =======" -ForegroundColor Yellow
$privateKey

Write-Host "`nJSON value (Save to Jwt.SigningKey.PrivateKey in appsettings.json):" -ForegroundColor DarkYellow
$privateKey | ConvertTo-Json

# Export Public Key (for the API and Node.js to verify tokens)
$publicKey = $rsa.ExportSubjectPublicKeyInfoPem()
Write-Host "`n======= PUBLIC KEY =======" -ForegroundColor Cyan
$publicKey

Write-Host "`nJSON value (Save to Jwt.SigningKey.PublicKey in appsettings.json):" -ForegroundColor DarkCyan
$publicKey | ConvertTo-Json

$rsa.Dispose()