# CalculateProjectModule

Микросервисная система для расчёта стоимости модульных домов и бань

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)
![Status](https://img.shields.io/badge/status-completed-brightgreen)

---

## О проекте

Расчёт стоимости дома или бани с учётом:
- Площади и типа строения
- Промокодов на скидку
- Доставки по городам
- Бонусных баллов

Технологии: ASP.NET Core Minimal API, EF Core, SQLite, HTML/CSS/JS, xUnit, Selenium.

---

## Архитектура

| Сервис | Порт | Описание |
|--------|------|----------|
| PriceService | 5001 | Расчёт цены |
| DiscountService | 5002 | Промокоды |
| DeliveryService | 5003 | Доставка + SQLite |
| BonusService | 5004 | Бонусы |
| MainService | 5000 | API Gateway |
| Frontend | 5005 | Веб-интерфейс |

---

## Запуск

```bash
cd backend
RunService.bat
