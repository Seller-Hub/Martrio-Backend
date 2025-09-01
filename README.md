# SellerHub Auth API – README 🚀 

This document describes the **Authentication (Auth)** module of the **SellerHub** project.  
It covers **login, registration, logout, and user information** endpoints.

---------------------------------------------------------------------------------------

## Overview ℹ️

- **Backend:** ASP.NET Core Web API  
- **Authentication:** Cookie-based for session management  
- **User Data:** Stored on the server; frontend identifies users automatically via cookies  
- **User ID:** Not required on the frontend; cookies handle identification  
- **Response Format:** JSON  
- **Security:** Passwords are hashed using `BCrypt`; never stored or returned in plain text (except for testing)

---------------------------------------------------------------------------------------

## Endpoints

### 1. Register 📝

**POST** `/auth/register`  

**Description:** Registers a new user.

**Request Body (JSON):**
```

{
  "name": "John Doe",
  "email": "example@gmail.com",
  "password": "Password123#",
  "role": "customer",
  "referralCode": "REF123",
  "linkedTo": 1
}

Response (Success):


{
  "message": "Registered successfully",
  "userId": 1,
  "name": "John Doe",
  "email": "example@gmail.com",
  "role": "customer",
  "referralCode": "REF123",
  "linkedTo": 1
}

Response (User already exists):


{
  "message": "User already exists"
}
---------------------------------------------------------------------------------------
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
  "userId": 1,
  "name": "John Doe",
  "email": "example@gmail.com",
  "role": "customer",
  "referralCode": "REF123",
  "linkedTo": 1
}

Response (Invalid credentials):


{
  "message": "Invalid credentials"
}

---------------------------------------------------------------------------------------
3. Logout 🚪
POST /auth/logout

Description: Logs out the currently authenticated user.

Request: Requires authentication via cookie.

Response:

{
  "message": "Logged out successfully"
}

---------------------------------------------------------------------------------------

4. Me 👤
GET /auth/me

Description: Retrieves information about the currently authenticated user via cookie.

Response:


{
  "message": "User info retrieved successfully",
  "userId": 1,
  "name": "John Doe",
  "email": "example@gmail.com",
  "role": "customer",
  "referralCode": "REF123",
  "linkedTo": 1
}

---------------------------------------------------------------------------------------

Key Notes ⚡

Authentication: Cookie-based. Frontend requests (via fetch or axios) automatically include the cookie.

JSON Format: All responses are in JSON for easy frontend integration.

Passwords: Passwords are hashed and never returned in production. Plain text passwords are only used in dev/testing.

Roles: User roles (customer, admin, seller) can be used to assign different permissions and access levels.

Referral System: ReferralCode and LinkedTo allow tracking of referrals and linked accounts.
