@echo off
start "PriceService" cmd /k "cd /d %~dp0PriceService && dotnet run"
start "DiscountService" cmd /k "cd /d %~dp0DiscountService && dotnet run"
start "DeliveryService" cmd /k "cd /d %~dp0DeliveryService && dotnet run"
start "BonusService" cmd /k "cd /d %~dp0BonusService && dotnet run"
start "MainService" cmd /k "cd /d %~dp0MainService && dotnet run"
start "Frontend" cmd /k "cd /d %~dp0..\frontend && dotnet run"