# ToursApp

Туристическое агентство 

Описание предметной области		

В рамках данного задания необходимо разработать систему для Туристического агентства «Путешествуй по России». Туристическое агентство также выступает как туристический оператор и сотрудничает со многими партнерами - страховыми компаниями, отелями, перевозчиками.					
В задачу туристического оператора входит формирование туров - готового туристического продукта, и формирование цен на тур. Продаваемые туры включают в себя перелеты, страховки, трансферы, питание и проживание в гостиницах. Стоимость туров, отелей, услуг и страховок определяются прейскурантом цен, установленным агентством на определённую дату. Все цены в прейскуранте должны быть в рублях. Все туры, отели и услуги подробно описаны и наглядно рекламируются фотографиями.
Турагентство работает как на рынке B2C и продает туры в розницу всем желающим, так и на рынке B2B. У туроператора есть постоянные крупные компании заказчики, которые покупают туры. Необходимо собирать и анализировать отзывы всех клиентов по турам, отелям и услугам.	
Агентство приняло решение расширить свой бизнес и выйти на мировой уровень, что позволит открыть ряд новых возможностей для компании и увеличить обороты. Для достижения данной цели было принято решение о создании информационной системы, в разработке которой вам и предстоит принять участие. 

База данных и импорт

Подготовлен скрипт (ms и my) для восстановления структуры БД. В процессе разработки приложения Вы можете изменять базу данных на свое усмотрение. Подготовьте данные файлов для импорта (в папке import) и загрузите в базу данных.

Desktop - Список туров

Необходимо отобразить список туров (в виде плитки), который должен соответствовать макету, предоставленному в ресурсах к заданию (пример в файле tours_page.png). Однако это не означает, что необходимо следовать макету в точности до пикселя - это всего лишь схема расположения элементов, на которую нужно ориентироваться при разработке пользовательского интерфейса.
Для каждого элемента необходимо отображать наименование тура, изображение тура, стоимость (в формате {price} РУБ), количество билетов и статус тура (Актуален или Не актуален). В зависимости от текущего статуса тура цвет текста должен быть зеленым или красным соответствующе. При отсутствии изображения у тура необходимо вывести картинку-заглушку из ресурсов (picture.png).
На странице со списком туров необходимо добавить возможность поиска туров по названию и описанию. Поиск должен работать в реальном времени (то есть без необходимости нажатия кнопки “найти”).
На странице со списком туров необходимо добавить возможность фильтрации списка по типу. Все типы из базы данных должны быть выведены в выпадающий список для фильтрации. Первым элементом в выпадающем списке должен быть “Все типы”, при выборе которого настройки фильтра сбрасываются. Помимо фильтрации по типу реализуйте возможность показа актуальных или всех туров с помощью установки/снятия соответствующей галочки (CheckBox). Фильтрация должна работать в реальном времени (то есть без необходимости нажатия кнопки “найти”).
Функции фильтрации и поиска должны применяться совместно к итоговой выборке.
Предусмотрите возможность отсортировать список по убыванию и возрастанию стоимости тура.
В правой верхней части экрана необходимо вывести информацию об общей стоимости туров, рассчитанную с учетом цены на тур и количества билетов. Данную информацию необходимо обновлять при поиске и сортировке.

Desktop - Таблица отелей

Необходимо отобразить список отелей в виде таблицы, содержащей следующую информацию: название отеля, количество звезд, название страны и количество имеющихся туров в этот отель. В крайнем правом столбце должны располагаться кнопки для редактирования информации о соответствующем отеле.
Так как отелей может быть достаточно много в базе данных, необходимо предусмотреть постраничный вывод информации с возможностью настройки количества элементов на странице (по умолчанию должно отображаться 10 отелей на каждой странице). Необходимо реализовать переходы на первую и последнюю, предыдущую и следующую страницы. Необходимо выводить актуальную информацию о количестве записей, количестве страниц и текущей странице.

Desktop - Таблица отелей - Удаление отеля

Должна быть реализована возможность удаления выбранных отелей. Удаление должно быть запрещено системой, если он находится в числе подходящих отелей для актуальных туров. Если нет, то отель может быть удален со всеми фотографиями после подтверждения пользователем. В сообщении необходимо вывести название выбранного отеля. После удаления отелей список необходимо обновить, равно как и информацию о количестве записей/страниц.

Desktop - Добавление/редактирование отеля

Так как информация об отелях может изменяться, необходима также реализация функций добавления и редактирования в новом окне - форме для добавления/редактирования отеля.
На форме должен быть предусмотрен ввод следующей информации: наименование отеля, количество звезд (целое значение от 0 до 5), описание отеля (многострочный), страна (выпадающий список с возможностью выбора одного элемента). Все поля обязательны для заполнения.
При открытии формы для редактирования все поля выбранного объекта должны быть подгружены в соответствующие поля из базы данных.
После редактирования/добавления отеля в БД данные в окне списка отелей должны быть обновлены.
