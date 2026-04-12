# API Endpoints Documentation

## AuthController
Base Route: `/api/Auth`

### Register
- **Endpoint**: `POST /api/Auth/register`
- **Body**: `RegisterMV model` (JSON)
- **Response**: `200 OK` on success, `400 BadRequest` on error.

### Login
- **Endpoint**: `POST /api/Auth/login`
- **Body**: `LoginMV model` (JSON)
- **Response**: `200 OK` on success, `401 Unauthorized` on error.

---

## BinController
Base Route: `/api/Bin`

### Create Bin
- **Endpoint**: `POST /api/Bin/Create`
- **Response**: `200 OK` with a newly created token string.

### Assign Bin
- **Endpoint**: `POST /api/Bin/Assign`
- **Authorization**: Required
- **Body**: `AssignBinMV Token` (JSON)
- **Response**: `200 OK` on success, `400 BadRequest` if assignment fails.

### Get All Bins
- **Endpoint**: `GET /api/Bin`
- **Authorization**: Required
- **Response**: `200 OK` with `List<BinMV>`.

### Get Bin Details
- **Endpoint**: `GET /api/Bin/{Id}`
- **Authorization**: Required
- **Route**: `int Id`
- **Response**: `200 OK` with `BinMV`, `404 NotFound` if bin is not found.

### Update Bin
- **Endpoint**: `PUT /api/Bin/Update`
- **Header**: `Token` (IdentificationToken)
- **Body**: `BinUpdateMV bin` (JSON)
- **Response**: `200 OK` with updated `BinMV`, `404 NotFound` if not found.

### Delete Bin
- **Endpoint**: `DELETE /api/Bin/Delete`
- **Header**: `Token` (IdentificationToken)
- **Response**: `200 OK` on success, `404 NotFound` if not found.

---

## BinSectionController
Base Route: `/api/BinSection`

### Update Bin Section
- **Endpoint**: `PUT /api/BinSection/update`
- **Header**: `Token` (token)
- **Body**: `BinSectionMV binSection` (JSON)
- **Response**: `200 OK` with updated `BinSectionMV`, `404 NotFound` if not found.

### Get All Bin Sections
- **Endpoint**: `GET /api/BinSection/Bin/{Id}`
- **Authorization**: Required
- **Route**: `int Id` (Bin Id)
- **Response**: `200 OK` with `List<BinSectionMV>`, `404 NotFound` if not found.

---

## CrowdDensityController
Base Route: `/api/CrowdDensity`

### Get Last State
- **Endpoint**: `GET /api/CrowdDensity`
- **Query**: `int BinId`
- **Response**: `200 OK` with Crowd Density Details, `404 NotFound` if no data available.

### Add Crowd Density
- **Endpoint**: `POST /api/CrowdDensity`
- **Header**: `Token` (token)
- **Body**: `CrowdDensityInsertMV crowdDensity` (Form-DatA)
- **Response**: `200 OK` on success, `400 BadRequest` on validation failure, `404 NotFound` if bin is not found.

---

## SurroundingWasteController
Base Route: `/api/SurroundingWaste`

### Get Last State
- **Endpoint**: `GET /api/SurroundingWaste`
- **Query**: `int BinId`
- **Response**: `200 OK` with Surrounding Waste Details, `404 NotFound` if no data available.

### Add Surrounding Waste
- **Endpoint**: `POST /api/SurroundingWaste`
- **Header**: `Token` (token)
- **Body**: `SurroundingWasteInsertMV waste` (Form-Data)
- **Response**: `200 OK` on success, `400 BadRequest` on validation failure, `404 NotFound` if bin is not found.

---

## TransactionController
Base Route: `/api/Transaction`

### Get All Transactions For A Bin
- **Endpoint**: `GET /api/Transaction/bin/{BinId}/page/{PageNumber}`
- **Authorization**: Required
- **Route**: `int BinId`, `int PageNumber`
- **Query**: `int PageSize` (Optional, defaults to 10)
- **Response**: `200 OK` with `List<TransactionResultMV>`, `401 Unauthorized` if not authorized.

### Add Transaction
- **Endpoint**: `POST /api/Transaction`
- **Header**: `Token` (token)
- **Body**: `TransactionInsertMV transaction` (Form-Data)
- **Response**: `200 OK` on success, `400 BadRequest` on failure.