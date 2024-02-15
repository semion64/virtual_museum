## Виртуальный музей

### Описание программы
* Программа представляет собой простую оболочку для виртуального музея, ориентированную на использование с интерактивными панелями.
* Изначально перед пользователем открывается текстовое меню с подразделами. После выбора интересующего раздела появляется содержимое раздела.
* Содержимое раздела может включать файлы изображений (.jpg, .png) (в разработке видео файлы (.mp4, .mpeg, .avi)).
* Пользователь с использованием стрелок на экране может переходить к следующему или предыдущему изображению.
* Имеется кнопка назад, которая позволяет вернуться из режима просмотра в меню с разделами.

### Установка 
1. Скчайте архив Release и разархивируйте в любую директорию
2. Запустите VirtualMuseum.exe
3. При необходимости установите .NET Framework 5.0
4. Добавьте в папку Data необходимую информацию
5. Для корректной работы, необходимо наличие Windows Media Player
6. Программа адаптирована под разрешение 1920х1080

#### Добавление информации в виртуальный музей
* В папку Data Следует поместить содержимое виртуального музея.
* Содержимое представляет собой иерхическую структуру вложенных директорий. Из имен директорий формируются разделы виртуального музея.
* Любая директория должна содержать либо только другие директории, либо только файлы. 
* Запрещено, чтобы в одной директории находились директории и файлы одновременно.
* Запрещены пустые директории.

#### Отображение в сортированном виде
* Имена файлов и директорий могут начинаться с указания префикса (например, порядкового номера). Префикс от названия отделяется знаком подчеркивания.
* Указание префиксов в именах позволит отображать информацию в сортированном виде.
* Название, которое будет отображаться в виртуальном музее, составляет часть имени файла или директории, расположенную справа от последнего подчеркивания.

#### Изменение оформления
* Просто замените файлы в папке pic, на свои изображения.
* Строго следите за соответствием размеров изображений шаблонным.
* Изображения поддерживают прозрачность.

### Для разработчиков
Программа написана в IDE VisualStudio 2022 и протестирована с использованием .NET Framework 5.0


