# WT-4. ASP.NET Core MVC — FlightApp

Веб-приложение для управления авиарейсами на **ASP.NET Core MVC (.NET 8)**.
Данные хранятся в памяти (без БД).

**Предметная область:** каталог рейсов с поиском, добавлением, редактированием и удалением.

---

## 🌐 Публичное приложение

👉 **https://wt-lab4-4mvc-rabtsevich.onrender.com/Flight**

---

## ⚙️ Функциональность

| Операция | Маршрут |
|---|---|
| Каталог рейсов | `GET /Flight` |
| Детали рейса | `GET /Flight/Details/{id}` |
| Добавление | `GET/POST /Flight/Create` |
| Редактирование | `GET/POST /Flight/Edit/{id}` |
| Удаление | `POST /Flight/Delete/{id}` |

- Валидация (DataAnnotations + jQuery Validation)
- Защита POST через `[ValidateAntiForgeryToken]`
- Адаптивная вёрстка на Bootstrap 5.3
- Поиск и статистика на странице каталога

---


## 📁 Структура
