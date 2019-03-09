declare @temp nvarchar(50)
set @temp = (select Name from Regions where Id = 478)

update Regions
set Name = (select Name from Regions where Id = 475)
where Id = 478

update Regions
set Name = @temp
where Id = 475