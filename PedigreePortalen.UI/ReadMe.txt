For at kunne køre programmet skal du vælge følgende som startup projects:
AnimalMicroService
HealthRecordMicroService
MatingCalculatorMicroService
UserMicroService
PedigreePortalen.UI

RabbitMQ:
Du skal have en RabbitMQ kørende i docker: (Kør denne command i CMD)
docker run -d --hostname pedigreeportalen --name RabbitMQ -p 15672:15672 -p 5672:5672 rabbitmq:3-management.

Login til RabbitMQ:
Brugernavn: guest
Kode: guest

Login på Hjemmesiden:
Brugernavn: Admin@contoso.com
Kode: Test123!