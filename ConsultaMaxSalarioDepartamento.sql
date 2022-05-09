Select d.Nome Departamento, p.Nome, p.Salario from Pessoa p
inner join Departamento d on p.DeptId = d.Id
where Salario in (select max(Salario) from Pessoa group by DeptId)










