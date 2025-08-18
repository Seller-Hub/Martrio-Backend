# SellerHub Auth API – README 🚀

This document describes the **Authentication (Auth)** module of the **SellerHub** project.  
It covers **login, registration, logout, and user information** endpoints.

---------------------------------------------------------------------------------------------------------

## Overview ℹ️

- **Backend:** ASP.NET Core Web API  
- **Authentication:** Cookie-based for session management  
- **User Data:** Stored on the server; frontend identifies users automatically via cookies  
- **User ID:** Not required on the frontend; cookies handle identification  
- **Response Format:** JSON  

---------------------------------------------------------------------------------------------------------


## Endpoints

### 1. Register 📝

**POST** `/auth/register`  

**Description:** Registers a new user.  

**Request Body (JSON):**
```
{
  "email": "example@gmail.com",
  "password": "Password123#",
  "role": "Customer"
}

Response (Success):

{
  "message": "Registered successfully",
  "email": "example@gmail.com",
  "role": "Customer"
}


Response (User already exists):

{
  "message": "User already exists"
}


2. Login 🔑

POST /auth/login

Description: Logs in an existing user.

Request Body (JSON):


{
  "email": "example@gmail.com",
  "password": "Password123#"
}


Response (Success):


{
  "message": "Logged in successfully",
  "email": "example@gmail.com",
  "role": "Customer"
}


Response (Invalid credentials):


{
  "message": "Invalid credentials"
}


3. Logout 🚪

POST /auth/logout

Description: Logs out the currently authenticated user.

Request: Requires authentication via cookie.

Response:

{
  "message": "Logged out successfully"
}


4. Me 👤

GET /auth/me

Description: Retrieves information about the currently authenticated user via cookie.

Response:

{
  "message": "User info retrieved successfully",
  "email": "example@gmail.com",
  "role": "Customer"
}

Key Notes ⚡

Authentication: Cookie-based. Frontend requests (via fetch or axios) automatically include the cookie.

JSON Format: All responses are in JSON for easy frontend integration.

Passwords: Returned in responses for testing purposes only. Do not use in production.

Roles: User roles (e.g., Customer, Admin) can be used to assign different permissions and access levels.
