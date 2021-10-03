param([string] $filename )
	$ownFile = gci $filename 
	$ownPath = $ownFile.PSParentPath | Convert-Path
	Write-Host $ownPath
	$parentPath = gci $filename -Recurse | ForEach-Object { $_.PSParentPath | Convert-Path }
	write-host $parentPath
	
	foreach ($folder in $parentPath) {
			if ($ownPath -eq $folder)
				{
					continue;
				}
	    copy $filename $folder
	}