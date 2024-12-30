# База даних для харчового підприємства

Інформаційні технології відіграють важливу роль у сучасному світі, забезпечуючи зберігання та обробку даних. Бази даних є ключовим елементом цих систем, дозволяючи ефективно структурувати інформацію та швидко отримувати доступ до неї.
Мета проєкту - створити базу даних для харчового підприємства, реалізувати основні функції через процедури та тригери, а також забезпечити цілісність і безпеку даних.
БД буде розроблятися на MySQL з використанням середовища PhpMyAdmin


### Варіант розроблюваної БД - 87: Харчове підприємство
Програмне забезпечення (ПЗ) має забезпечити облік замовлень і доставки продукції харчового підприємства клієнтам. Для полегшення роботи різні категорії продукції та їх склад треба зберігати з використанням динамічної ієрархії. Один вид продукції може належати кільком категоріям. Кожен з видів має кілька інгредієнтів.  
Слід передбачити можливість зберігання та супроводу інформації про:
- види продукції, їх склад і вагу, а також вартість;
- клієнтів харчового підприємства;
- облік замовлень клієнтів і їх доставки;
- акційні пропозиції;
- звіти щодо зроблених замовлень по видах продукції за вказаний період з метою виявлення найбільш популярних пропозицій;
- накопичувальна система знижок (відсоток знижки змінюється в залежності від суми всіх зроблених замовлень).  
Слід розробити графічний web-інтерфейс для ПЗ.

Information technology plays a vital role in the modern world, providing data storage and processing. Databases are a key element of these systems, allowing information to be efficiently structured and quickly accessed.
The goal of the project is to create a database for a food enterprise, implement key functions through procedures and triggers, and ensure data integrity and security.
The database will be developed in MySQL using the PhpMyAdmin environment.

Variant of the database being developed - 87: Food Enterprise
The software (SW) must ensure the management of orders and product delivery for the food enterprise's clients. To simplify operations, various product categories and their compositions should be stored using a dynamic hierarchy. A single product type may belong to multiple categories. Each product type includes several ingredients.
The software should provide storage and maintenance of information about:
- Product types, their composition, weight, and cost;
- Clients of the food enterprise;
- Management of client orders and their delivery;
- Promotional offers;
- Reports on completed orders by product types for a specified period to identify the most popular offers;
A cumulative discount system (the discount percentage changes depending on the total amount of all completed orders).
A graphical web interface should be developed for the software.


## Призначення бази даних

БД на харчовому підприємстві потрібна для полегшення ведення обліку товарів, їх складу, ціни, поточних акцій, поточних клієнтів та їх замовлень, а також придбаних товарів у цих замовленнях. БД спрощує створення звітів зроблених замовлень по видах продукції за вказаний період з метою виявлення найбільш популярних пропозицій.  
БД вирішує кілька основних задач: облік замовлень, управління доставкою, а також управління продукцією та клієнтами. Вона дозволяє створювати динамічну ієрархію продуктів, відстежувати склад кожного виду продукції, керувати клієнтською базою та автоматизувати процес обробки замовлень.

A database for a food enterprise is needed to streamline the management of products, their composition, prices, ongoing promotions, current clients, and their orders, as well as the purchased items within those orders. The database simplifies the creation of reports on completed orders by product types for a specified period, helping to identify the most popular offers.  
The database addresses several key tasks: order tracking, delivery management, and managing products and clients. It enables the creation of a dynamic product hierarchy, tracks the composition of each product type, manages the client base, and automates the order processing workflow.
