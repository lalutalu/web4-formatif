$apiUrl = "https://localhost:7020/api/products"

$productData = @{
    "Name" = "TestProduct";
    "Description" = "Testing the new product";
}

$jsonData = $productData | ConvertTo-Json

$response = Invoke-RestMethod -Uri $apiUrl -Method Post -Body $jsonData -ContentType "application/json"

$response

