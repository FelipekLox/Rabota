# Rabota — Система учета БПЛА и комплектующих

Настольное приложение на C# (Windows Forms, .NET Framework 4.7.2) для учета беспилотных летательных аппаратов и складских запасов запчастей с хранением данных в СУБД PostgreSQL.

## 1. Требования к системе

* **ОС:** Windows 10 / 11
* **Среда разработки:** Microsoft Visual Studio 2022 (с компонентом разработки классических приложений .NET)
* **База данных:** PostgreSQL 14+ и pgAdmin 4
* **NuGet-пакеты:** `Npgsql` (версия `4.1.14` для совместимости с .NET Framework 4.7.2)

## 2. Структура проекта

* `Drone.cs` — модель данных беспилотного летательного аппарата.
* `Part.cs` — модель данных запчасти / комплектующего.
* `DatabaseHelper.cs` — класс для подключения к PostgreSQL и выполнения SQL-запросов (CRUD).
* `MainForm.cs` — главная форма приложения с вкладками для управления дронами и запчастями.

## 3. Подготовка базы данных

1. Откройте **pgAdmin 4** и подключитесь к локальному серверу PostgreSQL.
2. Создайте новую базу данных с именем **`rabota_db`**.
3. Откройте **Query Tool** для созданной базы данных и выполните следующий SQL-скрипт для создания таблиц и добавления тестовых данных:

```sql
CREATE TABLE drones (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    model VARCHAR(100) NOT NULL,
    type VARCHAR(50),
    inventory_number VARCHAR(50) UNIQUE,
    status VARCHAR(50)
);

CREATE TABLE parts (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    category VARCHAR(50),
    quantity INT NOT NULL DEFAULT 0,
    storage_location VARCHAR(100)
);

INSERT INTO drones (name, model, type, inventory_number, status)
VALUES ('Разведчик-1', 'DJI Mavic 3', 'Квадрокоптер', 'INV-001', 'Исправен');

INSERT INTO parts (name, category, quantity, storage_location)
VALUES ('Пропеллер карбоновый', 'Винты', 12, 'Стеллаж А-1');
```

4. Откройте файл `DatabaseHelper.cs` в проекте и укажите ваш пароль от пользователя `postgres` в строке подключения `_connectionString`:

```csharp
private readonly string _connectionString =
    "Host=localhost;Port=5432;Database=rabota_db;Username=postgres;Password=ВАШ_ПАРОЛЬ;";
```

## 4. Сборка и запуск приложения

### Вариант А: Через Visual Studio (рекомендуемый)

1. Откройте файл решения **`Rabota.slnx`** в Visual Studio (убедитесь, что проект открыт в режиме *Представление решения*, а не *Представление папок*).
2. При необходимости восстановите пакеты NuGet: нажмите правой кнопкой мыши по решению в Обозревателе решений и выберите **Восстановить пакеты NuGet (Restore NuGet Packages)**.
3. Нажмите кнопку **Пуск (Start)** на верхней панели инструментов или клавишу **`F5`** для сборки и запуска приложения.

### Вариант Б: Через командную строку

1. Откройте **Developer Command Prompt for Visual Studio** (Командную строку разработчика).
2. Перейдите в корневую папку с проектом:
   ```cmd
   cd C:\Users\Admin\source\repos\Rabota
   ```
3. Восстановите зависимости и выполните сборку проекта через MSBuild:
   ```cmd
   nuget restore
   msbuild Rabota\Rabota.csproj /p:Configuration=Release
   ```
4. Запустите собранный исполняемый файл:
   ```cmd
   Rabota\bin\Release\Rabota.exe
   ```
