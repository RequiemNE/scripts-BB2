## Zip build, rename to current date and move to D: drive. ##

# Variables
$game = "BB2"
$destination = "D:\Unity Backups"

# Logic
$date = Get-Date -Format "yyyy-MM-dd"
$currentPath = (Get-Location).ToString()
$destinationName = $game + '-' + $date + ".zip"
Compress-Archive -Path "$($currentPath)\$($game)" -DestinationPath "$($currentPath)\$($destinationName)"
Copy-Item "$($currentPath)\$($destinationName)" -Destination $destination