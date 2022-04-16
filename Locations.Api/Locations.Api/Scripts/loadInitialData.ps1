$filepath = "$PSScriptRoot/dataLoad.csv"

Import-Csv $filepath |
ForEach-Object {
    $Body = @{
     physicalAddress = $_.physicalAddress
     zipCode = $_.zipCode
     city = $_.city
     }
     $JsonBody = $Body | ConvertTo-Json

    # The ContentType will automatically be set to application/x-www-form-urlencoded for
    # all POST requests, unless specified otherwise.
     $Params = @{
         Method = "Post"
         Uri = "https://localhost:44318/api/locations"
         Body = $JsonBody
         ContentType = "application/json"
     }
     Invoke-RestMethod @Params
}

