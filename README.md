# 📘 ProgrammingTest.API

## 🛠️ Tech Stack

- ASP.NET Core
- Entity Framework Core
- Swagger (Swashbuckle)
- JWT Bearer Authentication
- MediatR
- Clean Architecture

## 🛡️ Authentication

All endpoints (except `/login` and `/all-column-item`) require a **JWT token**.

### 🔐 Login

**POST** `/login`

```json
{
  "username": "admin",
  "password": "admin"
}
```

**Response:**

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6..."
}
```

---

## API List (Summary)

### 🧍 Get Body Fat Percentage

- Group the weight/fat percentage data by day, week, month, or year. If a group contains multiple records, the average value of each metric will be calculated
- Used on the Top page and My Record screen.
- The Top page is grouped by month by default.
- `GET /api/body-fat-percentage?type=0`
- Query param: `type` (0–3) 
- JWT required

**Response:**
```json
[
  {
    "month": "2025-07",
    "averageWeight": 68.5,
    "averageBodyFat": 18.2
  }
]
```

### 🧱 Input Column Item

- Used on the Column page.
- `POST /api/input-column-item`
- JWT required

**Request:**
```json
{
  "title": "Drink more water",
  "description": "At least 2L a day",
  "imageUrl": "https://image.com/water.jpg",
  "tags": "health"
}
```

**Response:**
```json
"35fa1580-69da-4c64-9f71-bc93a001ae7d"
```

### 🗂️ Get All Column Items

- Used on the Column page.
- Based on my observation of the Figma design and my analysis, the items on this column page are divided into four groups (Recommend Column, Recommend Diet, Recommend Beauty, and Recommend Health). Therefore, I have categorized these items into four separate groups. The front-end developer will group them accordingly to match the layout as designed in Figma based on the "Tags" field of each item.
- `GET /api/all-column-item`
- JWT is **not** required

**Response:**
```json
[
  {
    "id": 1,
    "title": "Drink more water",
    "description": "At least 2L a day",
    "imageUrl": "https://image.com/water.jpg",
    "tags": "health"
  }
]
```

### 📅 Get Date Achievement

- Used on the Top page and My Record screen.
- The front-end developer will calculate the achievement rate
    Formula: Achievement Rate = CompletedTasks / TotalTasks
- `GET /api/date-achievement?date=2025-08-03T00:00:00`
- JWT required

**Response:**
```json
{
  "date": "2025-08-03T00:00:00",
  "completedTasks": 5,
  "totalTasks": 7
}
```

### 📓 Input Diary

- API to be used after clicking the "Input Diary" button on the My Record screen.
- `POST /api/input-diary`
- JWT required

**Request:**
```json
{
  "thoughts": "Today I felt great after jogging!"
}
```

**Response:**
```json
"35fa1580-69da-4c64-9f71-bc93a001ae7d"
```

### 📚 Get Diary History

- Retrieve the list of diaries for the current user when accessing the My Record screen.
- `GET /api/diary-history`
- JWT required

**Response:**
```json
[
  {
    "id": 1,
    "thoughts": "Today was productive",
    "date": "2025-08-01T10:00:00"
  }
]
```

### 🏋️ Input Exercise

- API to be used after clicking the "Input Exercise" button on the My Record screen.
- `POST /api/input-exercises`
- JWT required

**Request:**
```json
{
  "name": "Running",
  "description": "30 minutes morning run",
  "duration": 30,
  "caloriesBurned": 250,
  "type": 0,
  "intensity": 2,
  "date": "2025-08-03T06:30:00"
}
```

**Response:**
```json
"35fa1580-69da-4c64-9f71-bc93a001ae7d"
```

### 🏃 Get Exercises Record

- Retrieve the list of exercise records for the current user when accessing the My Record screen.
- `GET /api/exercises-record`
- JWT required

**Response:**
```json
[
  {
    "name": "Running",
    "duration": 30,
    "caloriesBurned": 250,
    "type": "Cardio",
    "intensity": "High",
    "date": "2025-08-03T06:30:00"
  }
]
```

### 🍽️ Input Meal

- API to be used after clicking the "Input Meal" button on the Top page.
- `POST /api/input-meal`
- JWT required

**Request:**
```json
{
  "mealType": 1,
  "name": "Grilled chicken",
  "description": "with veggies",
  "imageUrl": "https://image.com/meal.jpg",
  "calories": 500,
  "protein": 40,
  "carbohydrates": 30,
  "fat": 20,
  "date": "2025-08-03T12:00:00"
}
```

**Response:**
```json
"35fa1580-69da-4c64-9f71-bc93a001ae7d"
```

### 🍴 Get Meal History

- Retrieve the list of meals for the current user when accessing the Top page.
- `GET /api/meal-history`
- JWT required

**Response:**
```json
[
  {
    "mealType": "Lunch",
    "name": "Grilled chicken",
    "calories": 500,
    "protein": 40,
    "carbohydrates": 30,
    "fat": 20,
    "date": "2025-08-03T12:00:00"
  }
]
```

---

## 📑 Enum Definitions

| Enum             | Values                                 |
|------------------|----------------------------------------|
| `mealType`       | 0: Breakfast, 1: Lunch, 2: Dinner, 3: Snack |
| `exerciseType`   | 0–5                                     |
| `intensity`      | 0: Low, 1: Medium, 2: High, 3: Extreme  |
| `groupByType`    | 0–3                                     |

---

## ✅ Intended Audience

- 🔧 Frontend developers
- 🖥️ Infrastructure/DevOps personnel
- 👩‍💻 QA/Testers

This document is designed to help non-backend teams understand input/output formats and endpoints clearly.