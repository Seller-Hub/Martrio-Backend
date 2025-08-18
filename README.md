SellerHub Auth API – README

This document describes the Authentication (Auth) module of the SellerHub project. It is primarily intended for frontend developers and covers the login, registration, logout, and user information endpoints.

Overview

The backend is built with ASP.NET Core Web API.

Cookie-based authentication is used to manage user sessions.

User data is stored on the server, and the frontend identifies users automatically through cookies.

The frontend does not need the user ID, as the cookie handles identification.

All endpoints return responses in JSON format.

Endpoints
1. Register

POST /auth/register

Description: Registers a new user.

Request Body (JSON):

{
  "email": "example@gmail.com",
  "password": "Password123#",
  "role": "Customer"
}


Response Body (JSON):

{
  "message": "Registered successfully",
  "email": "example@gmail.com",
  "role": "Customer"
}


If the user already exists:

{
  "message": "User already exists"
}

2. Login

POST /auth/login

Description: Logs in an existing user.

Request Body (JSON):

{
  "email": "example@gmail.com",
  "password": "Password123#"
}


Response Body (JSON):

{
  "message": "Logged in successfully",
  "email": "example@gmail.com",
  "role": "Customer"
}


If credentials are invalid:

{
  "message": "Invalid credentials"
}

3. Logout

POST /auth/logout

Description: Logs out the currently authenticated user.

Request: Requires authentication via cookie.

Response Body (JSON):

{
  "message": "Logged out successfully"
}

4. Me

GET /auth/me

Description: Retrieves information about the currently authenticated user via cookie.

Response Body (JSON):

{
  "message": "User info retrieved successfully",
  "email": "example@gmail.com",
  "role": "Customer"
}

Key Notes

Authentication: Cookie-based. Frontend requests (via fetch or axios) automatically include the cookie.

JSON Format: All responses are in JSON, making it easy to integrate with the frontend.

Passwords: Currently returned in responses for testing purposes. Do not use this in production.

Roles: User roles (e.g., Customer, Admin) can be used to assign different permissions and access levels.
