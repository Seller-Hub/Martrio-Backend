# SellerHub Auth API – README 🚀

This document describes the **Authentication (Auth)** module of the **SellerHub** project.  
It covers **login, registration, logout, and user information** endpoints.

--------------------------------------------------------------------------------------------------------------

## Overview ℹ️

- **Backend:** ASP.NET Core Web API  
- **Authentication:** Cookie-based session management  
- **User Data:** Stored on the server; frontend identifies users automatically via cookies  
- **User ID:** Not required on the frontend; cookies handle identification  
- **Response Format:** JSON  
- **Security:** Passwords are hashed using `BCrypt`; never stored or returned in plain text (except for testing)

--------------------------------------------------------------------------------------------------------------


### 🟦 Register

**POST** `/auth/register`  

**Description:** Registers a new user.

**Request Body:**
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

🟩 Login
POST /auth/login

Description: Logs in an existing user.

Request Body:

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

🟧 Logout
POST /auth/logout

Description: Logs out the currently authenticated user.

Request: Requires authentication via cookie.

Response:

{
  "message": "Logged out successfully"
}

🟪 Me
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

Key Notes ⚡

Authentication: Cookie-based. Frontend requests (via fetch or axios) automatically include the cookie.

JSON Format: All responses are JSON for easy frontend integration.

Passwords: Passwords are hashed and never returned in production. Plain text passwords are only used in dev/testing.

Roles: User roles (customer, admin, seller) can be used to assign different permissions and access levels.

Referral System: ReferralCode and LinkedTo allow tracking of referrals and linked accounts.




🛒 SellerHub – Dashboard & Product Management System

1️⃣ Seller Dashboard 📊

Home Page Statistics

Total Sales

Total Orders

Store Sessions

Overall Sales

Regional Sales

Orders Overview

Completed ✅

Cancelled ❌

Ongoing ⏳

Top Selling Products

Display top-performing products based on sales ⭐

2️⃣ Product Management 🛍️
Product Listing

View all products belonging to the seller

Search & Filter System

Search by Name or Product Code 🔍

Filter by Category 🏷️

Stock Status (In stock, Low stock, Out of stock)

Price Range 💵

Stock Status & Visibility

Clearly shows current stock levels and product visibility 👁️

3️⃣ Product Categories 🏷️

Create new categories ➕

List existing categories 📂

Assign multiple categories to a single product 🔗

4️⃣ Bulk Edit ✏️

Update multiple products at once:

Stock

Price

Visibility

Categories

5️⃣ Backend & Database 🗄️

Built with EF Core and Relational Database ⚙️

Navigation properties and composite keys (Product ↔ ProductCategory)

Optimized queries for search, filter, and bulk edit 🚀

✅ Summary

SellerHub provides a complete seller dashboard, flexible product management, category handling, and bulk edit functionalities with robust backend architecture.
