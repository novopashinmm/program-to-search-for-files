# program-to-search-for-files
First commit
Внимание! Прежде чем запускать программу нужно зайти в редактор реестра и добавить
HKEY_CURRENT_USER->Software-> дирректорию AppFind

Написана программа для поиска файлов по заданным критериям:
Программа реализована на Windows Forms.
Основные параметры поиска:
— Стартовая директория (с которой начинается поиск)
— Шаблон имени файла (должна быть возможность использовать шаблонные символы * и ? как в Windows)
— Текст содержащийся в файле
— Ограничения по атрибутам: искать только с определенными атрибутами (Системный, Скрытый, Архивный)
— Флаг контролирующий нужно ли обрабатывать поддиректории. Если установлен значит надо искать файлы как в стартовой так и во всех вложенных директориях.
Все параметры применяются по правилу И — т.е. комбинируются вместе для более узкого поиска.
На главном окне также должен быть элементы:
1. отображающий какой файл обрабатывается в данный момент (имя файла с полным путем)
2. отображающий список найденных файлов (полный путь)
3. Отображающий количество обработанных файлов и прошедшее время
Эти элементы должны обновляться в реальном времени
Так же надо реализовать следующие команды:
— Начать поиск
— Остановить поиск (т.е. поиск должен быть прерван в любое время а не только когда обработает все файлы)
— Сохранить результаты — записывает в текстовый файл все найденные файлы с полными путями.
— Сохранить параметры — все введенные параметры должны сохраняться и при запуске программы считываться и устанавливаться автоматически.
