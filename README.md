📌 Overview

StaySync is an ASP.NET Core Web API project for hotel management. The system manages hotels, room types, rooms, guests, reservations, stays, payments, additional services, and real-time notifications.

The project includes:

REST API
GraphQL API
SignalR notifications
Entity Framework Core
Unit & Integration Tests
Clean multilayer architecture


🚀 Main Features
Hotels & Rooms
Create/edit/deactivate hotels
Manage room types and rooms
Track free and occupied rooms
Filter available rooms by period
Guests & Reservations
Manage guest profiles
Create and manage reservations
Confirm, cancel, and reschedule reservations
Track reservation history
Stay Management
Guest check-in
Guest check-out
Track active and completed stays
Payments & Services
Create payments
Add additional services to reservations
Calculate total reservation amount
Real-Time Notifications

SignalR notifications for:

New reservations
Reservation status changes
Check-in/check-out events
Payments
Room availability updates

🧠 Business Rules
Reservations cannot be created for inactive hotels or rooms
Rooms cannot have overlapping active reservations
Check-out date must be after check-in date
Cancelled reservations cannot be checked in
Payments must be valid and positive
Negative prices are not allowed
Completed or cancelled reservations cannot be freely edited

🧪 Testing

The project includes:

Minimum 12 unit tests
Minimum 8 integration tests

📄 Documentation

The project contains:

XML comments
Swagger documentation
README instructions
Git commit history
