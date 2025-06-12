# Процесс выполнения практики

## 1. Настройка Git и репозитория

**Создан личный репозиторий на GitHub**
- Репозиторий создан на основе предоставленного шаблона
- Настроена структура каталогов согласно требованиям
- Добавлены файлы `.gitignore` и `README.md`

**Освоены базовые команды Git**:
```bash
git clone <url_repository>      # Клонирование репозитория
git checkout -b feature_branch  # Создание новой ветки
git add .                       # Добавление изменений
git commit -m "Сообщение"       # Создание коммита
git push origin main            # Отправка изменений
```

## 2. Изучение синтаксиса Markdown

Освоены основные элементы разметки:

- **Заголовки** (`#`, `##`, `###`)
- **Форматирование текста** (жирный, курсив)
- **Списки** (нумерованные и маркированные)
- **Ссылки и изображения**
- **Таблицы**
- **Блоки кода**

---

## 3. Разработка проекта на платформе nanoFramework (ESP32-C3 Hydroponics)

### Структура проекта

Проект реализован на основе архитектуры с разделением на логические слои:

```bash
ESP32 C3 Hydroponics/
├── Hydroponics.Application/       # Бизнес-логика, сущности и абстракции
│   ├── Abstracts/
│   │   ├── AbstractHydroponicsConfiguration.cs
│   │   └── Devices/
│   │       ├── AbstractBuzzer.cs
│   │       ├── AbstractDevice.cs
│   │       ├── AbstractDrive.cs
│   │       └── AbstractSoilHygrometer.cs
│   ├── Common/Diagnostics/
│   │   └── AccumulatingStopwatch.cs
│   ├── Entities/
│   │   ├── Alarm/
│   │   │   ├── Alarm.cs
│   │   │   └── AlertValue.cs
│   │   └── FlowControl/
│   │       ├── FlowControl.cs
│   │       └── FlowLimit.cs
│   └── Hydroponic.cs
│
├── Hydroponics.Infrastructure/    # Конкретные реализации устройств и инфраструктуры
│   ├── Implementations/Application/Devices/
│   │   ├── Buzzer.cs
│   │   ├── Drive.cs
│   │   └── SoilHygrometer.cs
│
└── Hydroponics.ESP32_C3/          # Точка входа и конфигурация хоста
    ├── HydroponicsConfiguration.cs
    ├── Program.cs
    └── Services/Background/
        └── HydroponicService.cs
```

### Использованные технологии

- **nanoFramework** — специализированный фреймворк .NET для микроконтроллеров ESP32.
- **Generic Host** — используется для конфигурации и запуска приложения, управления жизненным циклом сервисов и Dependency Injection.
- **Dependency Injection** — архитектурный подход для повышения модульности, тестируемости и поддерживаемости кода.

### Особенности реализации

- Проект реализован с использованием **BackgroundService**, предназначенного для выполнения долговременных задач в отдельном потоке.
- Метод `ExecuteAsync()` класса `HydroponicService` запускает главный блокирующий цикл управления гидропоникой через метод `Hydroponic.Run()`.
- Host автоматически управляет жизненным циклом приложения, обеспечивая его надежный запуск и корректную работу.