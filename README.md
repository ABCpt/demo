Тестовое задание

Общее описание

На экране в портретной ориентации по 3-м лайнам сверху вниз двигаются враги. Игрок перемещается по нижней части игрового поля и отстреливает врагов, чтобы не допустить достижения ими финишной черты.

Описание задачи

Логика персонажа

Персонаж находится в нижней части экрана, игрок осуществляет управление персонажем клавишами WASD;
Передвижения персонажа ограничены прямоугольной областью. Слева, справа, снизу - границами экрана, сверху - линией финиша;
Персонаж автоматически стреляет по ближайшему из врагов в радиусе своего поражения.

Логика врагов

Враги спавнятся случайным образом в одной из трех точек спавна, с заданным таймаутом;
Враг движется по прямой из верхней части вниз с заданной скоростью;
Пересекая линию финиша враг уменьшает здоровье игрока на 1 и исчезает;
При попадании персонажа по врагу здоровье врага уменьшается на величину урона персонажа;
Когда здоровье врага становится равно 0 он умирает.

Победа и поражение

Игрок побеждает, когда все враги умирают;
Игрок проигрывает, когда его здоровье становится равно 0.

Интерфейс

В верхней части экрана отображается счетчик здоровья;
При поражении открывается окно с заголовком "Поражение" и кнопкой “Рестарт”, по нажатию на которую игра начинается заново;
При победе открывается окно с заголовком "Победа" и кнопкой “Рестарт”, по нажатию на которую игра начинается заново.

Настройки

Количество врагов, которое следует уничтожить для победы (range int); при каждом запуске игры количество врагов выбирается случайным образом из диапазона [min, max];
Таймаут с которым враги появляются (range float), следующий враг появляется через случайное число секунд из диапазона [min, max];
Скорость движения врагов (range float), скорость каждого нового врага выбирается случайно из диапазона [min, max];
Количество здоровья врагов (int);
Радиус поражения(стрельбы) персонажа (float);
Скорость стрельбы персонажа (float);
Урон от выстрела персонажа (int);
Скорость пули (float).

Технические требования

Нужно использовать строго Unity 2022.2.17f1;
Проект должен быть строго 2D
Реализовать спавн врагов используя паттерн "фабрика"
Ориентация сцены - вертикальная;
Календарный срок выполнения: менее 1 недели;
Фактическое время выполнения: 16 часов;
Выполненное тестовое задание нужно залить на GitHub;
Можно использовать любые ассеты из Unity Asset Store или других источников
