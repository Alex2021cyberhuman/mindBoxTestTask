# mindBoxTestTask
# Тестовое задание в компанию Mindbox.

отклик на вакансию
C# developer junior / middle (.net, full-stack / back-end)
Для отклика на эту вакансию необходимо ответить на несколько вопросов работодателя.

Ряд вопросов, на которые нет правильных ответов. С их помощью мы надеемся понять вашу способность мыслить, анализировать и добывать информацию, узнать вас и ваш бэкграунд получше. 

Выполните практическое задание ниже.

Отклики без выполненного задания не будут рассмотрены.

Пожалуйста, не пишите код внутри форм ответов, разместите его на Github и приложите ссылку. Если в задании что-то непонятно, опишите возникшие вопросы и сделанные предположения. Например, в комментариях в коде.

# Задание 1:

Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. Дополнительно к работоспособности оценим:

Юнит-тесты
Сделаны в проекте ShapeAreaCalculator.UnitTests.
Следуют принципам AAA. Использованы абстрактные тесты, для тестирования нескольких реализаций.
Добавлены бенчарки.

Легкость добавления других фигур
Добавил конструктор на основе рефлексии (ReflectionBasedConstructor.cs), который позволяет легко создавать фигуры без какой-либо необходимости регистрировать его в switch или его фабрику в контейнере di - требуется только добавить сборку в параметре scanningAssemblies, например, такой механизм реализован в MediatR для поиска обработчиков запросов.

Другие реализации требуют изменения кода библиотеки для добавиления новых фигур.

Вычисление площади фигуры без знания типа фигуры в compile-time
Реализации IShapeConstructor позволяет создать фигуру без знания ее типа в compile type, например как ответ на HTTP запрос в котором у нас передаются параметры для создания и тип ожидаемой фигуры. Модуль Фигуры должены реализовать интерфейс IShapeWithArea. Класс ReflectionBasedConstructor может работать с фигурами, которые создают клиенты библиотеки.

Проверку на то, является ли треугольник прямоугольным
Структура Tirangle реализует проверку CheckIsRight

# Решение в проектах ShapeAreaCalculator
* ShapeAreaCalculator.Core - библиотека для внешних клиентов
* ShapeAreaCalculator.UnitTests - Юнит-тесты
* ShapeAreaCalculator.Benchmarks - бенчмарки реализаций вычисления


# Задание 2:

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

Также без выполненного задания отклик не будет рассмотрен.

Github или Pastebin всё еще удобнее чем поле на hh. По возможности — положите ответ рядом с кодом из первого вопроса.

# Решение в файле Sql/answer.sql

Если надо выводить именно «Имя продукта – Имя категории», то можно реализовать проверку в select - если у категории не указан заголовок 
(это будет работать для продуктов без категорий при left join), выводить имя продукта, иначе объединять строки: имя продукта, тире, имя категории.
