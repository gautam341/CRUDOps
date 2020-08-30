sp_helptext sp_Vehicle_Delete
sp_helptext sp_Vehicle_Add
sp_helptext		
sp_helptext sp_Vehicle_All

create procedure sp_Vehicle_Delete  
@Id int   
as   
begin  
delete from Vehicle where Id=@Id  
end