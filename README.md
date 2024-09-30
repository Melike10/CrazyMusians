# Crazy Musicians Web API

This project is a simple ASP.NET Core Web API for managing a list of musicians. The API allows clients to perform various operations such as retrieving, adding, updating, and deleting musicians. Additionally, it supports partial updates using JSON Patch.

## Technologies Used

- **.NET 8**
- **ASP.NET Core**
- **Swagger**
- **Newtonsoft.Json** for handling JSON Patch

## Endpoints

### 1. Get All Musicians
**GET** `/CrazyMusician`

Retrieves the list of all musicians.

#### Response Example:
```json
[
    {
        "id": 1,
        "name": "Ahmet Çalgı",
        "job": "Ünlü Çalgı Çalar",
        "funSpeciality": "Her zaman yanlış nota çalar ama eğlencelidir."
    },
    {
        "id": 2,
        "name": "Zeynep Melodi",
        "job": "Popüler Melodi Yazarı",
        "funSpeciality": "Şarkıları yanlış anlaşılır ama çok popüler"
    }
]
```

### 2. Get Musician By ID
GET /CrazyMusician/{id}

Retrieves a specific musician by their ID.

### 3. Search Musicians by Name
GET /CrazyMusician/search?name={name}

Searches for musicians whose names contain the specified query string (case-insensitive).

### 4. Add a New Musician
POST /CrazyMusician

Creates a new musician. The ID is automatically generated.

Request Example:
```json

{
    "name": "John Doe",
    "job": "Jazz Musician",
    "funSpeciality": "Plays multiple instruments at the same time."
}
```

Response Example:
```json

{
    "id": 3,
    "name": "John Doe",
    "job": "Jazz Musician",
    "funSpeciality": "Plays multiple instruments at the same time."
}
```
### 5. Update Musician (PUT)
PUT /CrazyMusician/{id}

Updates an existing musician's information.

Request Example:
```json

{
    "id": 1,
    "name": "Ahmet Çalgı",
    "job": "Ünlü Çalgı Çalar",
    "funSpeciality": "Her zaman doğru nota çalar."
}
```
### 6. Partial Update Musician (PATCH)
PATCH /CrazyMusician/{id}/{newFunSpeciality}

Partially updates a musician’s fun specialty using JSON Patch.

Request Example:
``` json

[
    {
        "op": "replace",
        "path": "/FunSpeciality",
        "value": "Yenilikçi müzikler üretir."
    }
]
```
### 7. Delete Musician
DELETE /CrazyMusician/{id}

Deletes a musician by their ID.
