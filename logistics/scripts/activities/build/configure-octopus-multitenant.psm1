<#
.DESCRIPTION
    Injects the ODS connection string and the populatedSandbox key and secret into the Admin database for a Tenant
#>
function Invoke-ConfigureOctopusTenant {
    param(
        [Parameter(Mandatory = $true)]
        [string] $TenantPopulatedSandboxKey,

        [Parameter(Mandatory = $true)]
        [string] $TenantPopulatedSandboxSecret,

        [Parameter(Mandatory = $true)]
        [string] $TenantIdentifier,

        [Parameter(Mandatory = $true)]
        [string] $TenantOdsIdentifier,

        [Parameter(Mandatory = $true)]
        [string] $TenantVendorName,

        [Parameter(Mandatory = $true)]
        [string] $TenantsJson,

        [Parameter(Mandatory = $true)]
        [string] $ConnectionString
    )

    # Replace "{0}" with the value of the tenantIdentifier variable
    $tenantODSDatabaseCS = $ConnectionString -f $TenantOdsIdentifier

    Write-Host "Installing tenant configuration"
    Write-Host "TenantIdentifier: $TenantIdentifier"

    Write-Host "PrepopulatedKeyTenant: $TenantPopulatedSandboxKey"
    Write-Host "PrepopulatedSecretTenant: $TenantPopulatedSandboxSecret"

    # Convert the JSON data to a PowerShell object
    $tenants = ConvertFrom-Json $TenantsJson

    # Now you can access the individual properties of the tenants

    $tenantAdminDatabaseCS = $tenants.($TenantIdentifier).ConnectionStrings.EdFi_Admin

    # Print the connection strings (just for demonstration purposes)
    Write-Host "Tenant ODS Connection String: $TenantODSDatabaseCS"
    Write-Host "Tenant Admin Connection String: $TenantAdminDatabaseCS"

    $sql = @"
    -- EdFi_Admin

    DELETE from dbo.ApiClientOdsInstances
    DELETE from dbo.OdsInstances 
    DELETE from dbo.ApplicationEducationOrganizations
    DELETE from dbo.ApiClients
    DELETE from dbo.Applications
    DELETE from dbo.VendorNamespacePrefixes 
    DELETE from dbo.Vendors 

    DECLARE @VendorId NVARCHAR(225);
    DECLARE @ApplicationId NVARCHAR(225);

    INSERT INTO dbo.Vendors (
        VendorName
    )
    VALUES 
        ('$TenantVendorName');

    SELECT @VendorId=VendorId  from dbo.Vendors where VendorName ='$TenantVendorName';

    INSERT INTO dbo.VendorNamespacePrefixes (
        NamespacePrefix,
        Vendor_VendorId
    )
    VALUES 
        ('uri://ed-fi.org', @VendorId);

    INSERT INTO dbo.Applications (
        ApplicationName,
        OperationalContextUri,
        Vendor_VendorId,
        ClaimSetName
    )
    VALUES 
        ('SwaggerUI', 'uri://ed-fi.org', @VendorId, 'Ed-Fi Sandbox');

    SELECT @ApplicationId=ApplicationId  from dbo.Applications where Vendor_VendorId =@VendorId and ApplicationName = 'SwaggerUI';

    INSERT INTO dbo.ApplicationEducationOrganizations (
        EducationOrganizationId,
        Application_ApplicationId
    )
    VALUES 
    ('255901001', @ApplicationId);
        
    INSERT INTO dbo.ApiClients (
        [Key],
        [Secret],
        [Name],
        IsApproved,
        UseSandbox,
        SandboxType,
        SecretIsHashed,
        Application_ApplicationId
    )
    VALUES 
        ('$TenantPopulatedSandboxKey', '$TenantPopulatedSandboxSecret', '$TenantIdentifier', 1, 0, 0, 0, @ApplicationId);

    INSERT INTO dbo.ApiClientApplicationEducationOrganizations (
        ApiClient_ApiClientId,
        ApplicationEducationOrganization_ApplicationEducationOrganizationId
    )

    SELECT 
        ApiClients.ApiClientId,
        ApplicationEducationOrganizations.ApplicationEducationOrganizationId
    FROM
        dbo.ApiClients
    CROSS JOIN
        dbo.Applications
    INNER JOIN
        dbo.ApplicationEducationOrganizations ON
        Applications.ApplicationId = ApplicationEducationOrganizations.Application_ApplicationId
    WHERE
        ApiClients.Name = '$TenantIdentifier'
        AND
        Applications.ApplicationName = 'SwaggerUI'
        AND 
        Applications.Vendor_VendorId = @VendorId
        AND
        ApiClients.Application_ApplicationId = @ApplicationId;

    INSERT INTO dbo.OdsInstances (
        [Name],
        InstanceType,
        ConnectionString
    )
    VALUES 
        ('$TenantIdentifier Populated Sandbox', 'Sandbox', '$TenantODSDatabaseCS');


    INSERT INTO dbo.ApiClientOdsInstances (
        ApiClient_ApiClientId,
        OdsInstance_OdsInstanceId
    )
    SELECT 
        ApiClients.ApiClientId,
        OdsInstances.OdsInstanceId
    FROM 
        dbo.OdsInstances
    CROSS JOIN 
        dbo.ApiClients
    WHERE 
        OdsInstances.[Name] = '$TenantIdentifier Populated Sandbox'
        AND
        ApiClients.[Name] = '$TenantIdentifier'
        AND  
        ApiClients.Application_ApplicationId = @ApplicationId;
"@

    Invoke-SqlCmd -ConnectionString $tenantAdminDatabaseCS -Query $sql 
}