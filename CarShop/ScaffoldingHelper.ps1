param (
  [string]$source = "carShop",
  [string]$target = "carShop"
 )

Set-Location $PSScriptRoot
Get-ChildItem -Path $PSScriptRoot -Filter *$source* -Recurse | 
Foreach-Object {

    $targetFileName =  $_.Name.Replace($source, $target);
    Write-Host "Source: $_"
    Write-Host "Target: $targetFileName"
    
    Rename-Item $_.FullName $_.FullName.Replace($source, $target);
}

Get-ChildItem -Path $PSScriptRoot -Filter *.cs -Recurse | 
Foreach-Object {
  $fileContents = [System.IO.File]::ReadAllText($_.FullName)
    if ( $fileContents.Contains($source) )
    {
     Write-Host "Updating File Content On:" $_.Name
     $fileContents = $fileContents.Replace($source, $target);
     [System.IO.File]::WriteAllText($_.FullName, $fileContents)
    }
}

Get-ChildItem -Path $PSScriptRoot -Filter *.ps1 -Recurse | 
Foreach-Object {
  $fileContents = [System.IO.File]::ReadAllText($_.FullName)
    if ( $fileContents.Contains($source) )
    {
     Write-Host "Updating File Content On:" $_.Name
     $fileContents = $fileContents.Replace($source, $target);
     [System.IO.File]::WriteAllText($_.FullName, $fileContents)
    }
}

Get-ChildItem -Path $PSScriptRoot -Filter *.sql  -Recurse | 
Foreach-Object {
  $fileContents = [System.IO.File]::ReadAllText($_.FullName)
    if ( $fileContents.Contains($source) )
    {
     Write-Host "Updating File Content On:" $_.Name
     $fileContents = $fileContents.Replace($source, $target);
     [System.IO.File]::WriteAllText($_.FullName, $fileContents)
    }
}

Get-ChildItem -Path $PSScriptRoot -Filter *.csproj -Recurse | 
Foreach-Object {
  $fileContents = [System.IO.File]::ReadAllText($_.FullName)
    if ( $fileContents.Contains($source) )
    {
     Write-Host "Updating File Content On:" $_.Name
     $fileContents = $fileContents.Replace($source, $target);
     [System.IO.File]::WriteAllText($_.FullName, $fileContents)
    }
}

Get-ChildItem -Path $PSScriptRoot -Filter *Dockerfile -Recurse | 
Foreach-Object {
  $fileContents = [System.IO.File]::ReadAllText($_.FullName)
    if ( $fileContents.Contains($source) )
    {
     Write-Host "Updating File Content On:" $_.Name
     $fileContents = $fileContents.Replace($source, $target);
     [System.IO.File]::WriteAllText($_.FullName, $fileContents)
    }
}

Get-ChildItem -Path $PSScriptRoot -Filter *.yml -Recurse | 
Foreach-Object {
  $fileContents = [System.IO.File]::ReadAllText($_.FullName)
    if ( $fileContents.Contains($source) )
    {
     Write-Host "Updating File Content On:" $_.Name
     $fileContents = $fileContents.Replace($source, $target);
     [System.IO.File]::WriteAllText($_.FullName, $fileContents)
    }
}

Get-ChildItem -Path $PSScriptRoot -Filter *.sln -Recurse | 
Foreach-Object {
  $fileContents = [System.IO.File]::ReadAllText($_.FullName)
    if ( $fileContents.Contains($source) )
    {
     Write-Host "Updating File Content On:" $_.Name
     $fileContents = $fileContents.Replace($source, $target);
     [System.IO.File]::WriteAllText($_.FullName, $fileContents)
    }
}

Get-ChildItem -Path $PSScriptRoot -Filter *.ts -Recurse | 
Foreach-Object {
  $fileContents = [System.IO.File]::ReadAllText($_.FullName)
    if ( $fileContents.Contains($source) )
    {
     Write-Host "Updating File Content On:" $_.Name
     $fileContents = $fileContents.Replace($source, $target);
     [System.IO.File]::WriteAllText($_.FullName, $fileContents)
    }
}