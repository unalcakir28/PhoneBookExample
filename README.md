# PhoneBookExample
#### RabbitMQ kurulumunu yapın ve aşağıda belirtilen konumlardan kullanıcı bilgilerini güncelleyin.<br />
PhoneBookExample\Report.Business\RabbitMQService.cs<br />
PhoneBookExample\Report.BackgroundWorker\Worker.cs<br />

#### PostgreSql kurulumunu yapın ve aşağıda belirtilen konumlardan kullanıcı bilgilerini güncelleyin.<br />
PhoneBookExample\Contact.Data\ContactDbContext.cs<br />
PhoneBookExample\Contact.API\appsettings.json<br />
PhoneBookExample\Report.Data\ReportDbContext.cs<br />
PhoneBookExample\Report.API\appsettings.json<br />

#### Uygulamayı çalıştırıp test etmek için Çözüm > Özellikler sekmesinden birden fazla başlangıç projesi seçerek aşağıdaki sıralama ile projeyi başlatın.<br />
1- Contact.API<br />
2- Report.API<br />
3- Gateway<br />
4- Report.BackgroundWorker<br />

Tüm uygulamalar çalıştıktan sonra https://localhost:7127 linkinde çalışan gateway üzerinden testleri yapılabilir.<br />
Gateway için Swagger kurulumu yapılmıştır. Tüm endpointleri görüntüleyebilirsiniz.<br />
