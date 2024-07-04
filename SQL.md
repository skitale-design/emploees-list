### Написать и приложить скрипты для:

выборки всех сотрудников,

```sql

SELECT \* FROM [EmploeeDb].[dbo].[Emploees]

```

сотрудников у кого зп выше 10000,

```sql

SELECT \* FROM [EmploeeDb].[dbo].[Emploees] where Salary > 10000

```

удаления сотрудников старше 70 лет,

```sql

DELETE FROM [EmploeeDb].[dbo].[Emploees] where (DATEDIFF(year,CONVERT(date,BirthDate,3),CONVERT(date,GETDATE(),3))) < 70

```

обновить зп до 15000 тем сотрудникам, у которых она меньше.

```sql

UPdate [EmploeeDb].[dbo].[Emploees] set Salary = 15000 where Salary < 15000

```
