use master
go
IF DB_ID('estudiantedb') IS NOT NULL drop database estudiantedb
go
create database estudiantedb
go
use estudiantedb
go

create table [login] 
(
id int not null primary key identity,
usuario varchar(25) not null unique,
contrasena varchar(20) not null
);

go
select * from [login]
go
--select * from telefono_estudiante
insert into login (usuario, contrasena) values ('Felix', '12345'),
												('Jimmy', '12345'),
												('Noe', '12345'),
												('Frandely', '12345');

go
create table permiso_login
(
id_usuario int not null foreign key(id_usuario) references [login](id),
permiso char(2) not null check (permiso in ('TO', 'ED', 'EL','IN')),
primary key(id_usuario, permiso)
);

go
insert into permiso_login values (1,'ED'),
								 (2,'TO'),
								 (3,'TO'),					
								 (4,'TO');
								

--(1,'CR'),
--(1,'ED'),
--(1,'EL'),
								 

go
create table estudiante
(
matricula int not null primary key identity,
nombre varchar(35) not null,
apellido varchar(35) not null,
sexo char(1) not null check (sexo in ('M','F','N')),
direccion varchar(55) not null,
email varchar(40),
cedula char(11) not null,
unique(cedula),
nacionalidad varchar(15) not null,
--tanda char(1) check (tanda in ('M','T','N')),
--modalidad varchar(3) check (modalidad in ('FCC','FHP', 'FCP','FMT', 'FD', 'D')),
fecha_nacimiento char(10) not null check(fecha_nacimiento like '%[0-9][0-9]/[0-9][0-9]/[0-9][0-9][0-9][0-9]%'),
fecha_ingreso char(10) not null check(fecha_ingreso like '%[0-9][0-9]/[0-9][0-9]/[0-9][0-9][0-9][0-9]%'),
fecha_salida char(10) check(fecha_salida like '%[0-9][0-9]/[0-9][0-9]/[0-9][0-9][0-9][0-9]%' or fecha_salida like '%%'),
constraint chk_nacimiento check(fecha_nacimiento != fecha_ingreso and fecha_nacimiento != fecha_salida),
--constraint chk_ingreso check(fecha_ingreso != fecha_salida),
[status] bit not null check (status in (0,1)),
tipo_de_sangre char(2) check(tipo_de_sangre in ('A+', 'A-', 'B+', 'B-', 'O+', 'O-', 'N')) not null,
enfermedad varchar(20) default 'Ninguna',
ocupacion varchar(40) not null,
estado_civil char(1) not null check(estado_civil in ('S','C','V','U')),
nivel_academico varchar(25) not null
);
go 
--select * from estudiante
go
create table foto_estudiante
(
matricula int not null foreign key(matricula) references estudiante(matricula) on delete cascade on update cascade,
foto image not null,
primary key(matricula)
)



go
insert into estudiante 
(nombre, apellido, sexo, direccion, email, cedula, nacionalidad, fecha_nacimiento, fecha_ingreso, fecha_salida, [status], tipo_de_sangre,enfermedad,ocupacion, estado_civil, nivel_academico)
values  ('Felix', 'Caraballo', 'M','Calle Hermanas Mirabal, #83', 'noebido2017@gmail.com', '40222547445', 'Canadiense','01/12/2005', '01/08/2019', null, 1, 'O-','Sifilis','Estudiante','S','Educación terciaria'),
		('Carla', 'Smith', 'F','Calle La Rosa De Guadalupe', 'rositacarla@gmail.com', '40155547449', 'Inglesa', '05/10/2000', '07/09/2015', null, 1, 'A-',null,'Estudiante','C','Educación terciaria'),
		('Ramón', 'Rodriguez', 'M','Calle el Merengue', 'ramonr01@gmail.com', '22300058276', 'Fránces', '06/03/2001', '09/07/2019', null, 1, 'O+', null,'Estudiante','S','Educación terciaria'),
		('Carlos', 'Pérez', 'M','Calle La Rosa De Guadalupe, #2', 'carlosperez@gmail.com', '40164512253', 'Dominicano', '05/10/1988', '07/09/2023',null, 1, 'A-',null,'Estudiante','U','Educación terciaria'),
		('Virginia', 'Mota', 'F','Calle duarte', null, '40155544884', 'Dominicana', '05/10/2000', '07/09/2023', null, 1, 'N', null,'Estudiante','S','Educación terciaria')

go
--select * from estudiante
----select CONCAT(rh.hora_entrada, ' - ', rh.hora_salida) as rango from estudiante_curso_horario ech inner join rango_horario rh on ech.id_rango_horario = rh.id where matricula = 2 and id_curso = 8;
--select * from estudiante_inscripcion 
--select * from estudiante_curso_horario
--select * from rango_horario order by id

go
create table sede
(
id int not null primary key identity,
descripcion varchar(60) not null,
unique(descripcion)
);

insert into sede(descripcion) values ('Dirección Regional Metropolitana'), 
                                ('Dirección Regional Oriental'),
								('Dirección Regional Cibao Norte'),
								 ('Dirección Regional Cibao Sur'),
								 ('Dirección Regional Sur'),
								  ('Dirección Regional Este');

--go
--select * from sede
--declare @descripcion varchar(max)
--set @descripcion = 'Dirección Regional Metropolitana'
--select id from sede where descripcion = @descripcion

go
create table tipo_telefono
(
id int not null primary key identity,
tipo varchar(10) not null unique
);

go
insert into tipo_telefono (tipo) values ('t_1'),
                                        ('t_2'),
										('t_emg');

go
create table telefono_estudiante
(
id int not null primary key identity,
matricula int not null foreign key(matricula) references estudiante(matricula) on delete cascade on update cascade,
id_tipo_telefono int not null foreign key(id_tipo_telefono) references tipo_telefono(id) on delete cascade on update cascade,
telefono char(10) not null unique,
unique(matricula, id_tipo_telefono)
);


go
insert into telefono_estudiante (matricula, id_tipo_telefono, telefono) values (1,1,'8094216099'),
																				(1,2,'8098306090'),
																				(1,3,'8092395975'),
																				(2,1,'8490051489'),
																				(3,1,'8296537814'),
																				(4,1,'8296541100'),
																				(5,1,'8092269771'),
																				(5,3,'8498887412');

go
select * from telefono_estudiante
go
create table curso
(
id int not null primary key identity,
descripcion varchar(100) not null,
unique(descripcion)
);

go
insert into curso (descripcion) values ('Técnico en diseño y desarrollo de aplicaciones'),  --1
								  ('Técnico en operaciones de ventas'), --2
								  ('Diplomado en ciberseguridad y auditoría informática'), --3
								  ('Diplomado en fisioterapia'), --4
								  ('Asistencia de televisión'), --5
								  ('Auxiliar en infraestructura de redes'), --6
								  ('Maestro técnico en supervisión de servicios de mecánica y mantenimiento de máquinas industriales'), --7
								  ('Supervisión de servicios de soldadura'), --8
								  ('Técnico en cuidados de enfermería'), --9
								  ('Diplomado en gestión ambiental'), --10
								  ('Visita a médico'), --11
								  ('Programación web 4.0'), --12
								  ('Conservación de recursos naturales'); --13
								 

go
create table modulo
(
id int not null primary key identity,
descripcion varchar(45) not null,
unique(descripcion)
);

go
insert into modulo (descripcion) values ('Formación humana I'), --1
									('Seguridad y salud ocupacional'), --2
									('Emprendimiento'), --3
									('Matemática I'), --4
									('Inglés técnico'), --5
									('Historia y geografía'), --6
									('Contabilidad'), --7
									('Gramática básica'), --8
									('Sistema operativo'), --9
									('Base de datos'), --10
									('Diseño de página web'), --11
									('Comunicación oral y escrita'), --12
									('Procesos de soldadura básica'), --13
									('Física básica'), --14
									('Dibujo técnico II'), --15
									('Matemática aplicada'), --16
									('Enfermería clínica'), --17
									('Introducción al CSS'), --18
									('Mantenimiento y reparación de PC'); --19

go


--drop table curso_sede
create table curso_sede
(
--id int not null primary key identity,
id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
id_sede int not null foreign key(id_sede) references sede(id) on delete cascade on update cascade,
primary key(id_curso, id_sede)
);
go

insert into curso_sede (id_curso, id_sede) values (1,1), (2, 1), (3, 1), (4,1), (5,1), (6,1), (7,1), (8,1), (9,1), (10,1), (11,1), (12,1), (13,1),
												  (5,2), (6,2), (7,2), (8,2), (9,2), (10, 2), (11,2), (12,2), (13,2), 
												  (8,3), (9,3), (10,3), (11,3), (12,3), (13,3),
												  (12,4), (2,4), (3,4), (4,4), (5,4), (13,4),
												  (1,5), (2,5), (3,5), (4,5), (7,5), (13,5),
												  (12,6), (2,6), (3,6), (4,6), (5,6), (6,6), (13,6);
											
												
go



go
--drop table estudiante_sede

go

--drop table modulo_curso
create table modulo_curso
(
	id_modulo int not null foreign key(id_modulo) references modulo(id) on delete cascade on update cascade,
	id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
	primary key(id_modulo, id_curso)
);
--drop table modulo_curso
go
insert into modulo_curso(id_modulo, id_curso) values (1,1),(1,2), (1,3),
													 (2,1),(2,2),
													 (3,1),(3,2),
													 (4,1),(4,2),
													 (5,1),(5,2),
													 (6,1),(6,2),
													 (7,1),(7,2),
													 (8,1),(8,2),
													 (9,1),(9,2),
													 (10,1),(10,2),
													 (11,1),(11,2),
													 (12,1),(12,2),
													 (13,1),(13,2),

													 (1,4),(1,5), 
													 (2,4),(2,5),
													 (3,4),(3,5),
													 (4,4),(4,5),
													 (5,4),(5,5),
													 (6,4),(6,5),
													 (7,4),(7,5),
													 (8,4),(8,5),
													 (9,4),(9,5),
													 (10,4),(10,5),
													 (11,4),(11,5),
													 (12,4),(12,5),
													 (13,4),(13,5),

													 (10,6),(10,7),
													 (11,6),(11,7),
													 (12,6),(12,7),
													 (13,6),(13,7),

													 (10,8),(10,9),
													 (11,8),(11,9),
													 (12,8),(12,9),
													 (13,8),(13,9),

													 (10,12),(10,13),
													 (11,12),(11,13),
													 (12,12),(12,13),
													 (13,12),(13,13);




go
create table modalidad_curso
(
	modalidad varchar(3),
	id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
	primary key(modalidad, id_curso)
);

insert into modalidad_curso (modalidad, id_curso) values ('FCC',1),
														 ('FCC',2),
														 ('D',3),
														 ('D',4),
														 ('FD',5),
														 ('FHP',6),
														 ('FCC',7),
														 ('FD',8),
														 ('D',9),
														 ('D',10),
														 ('H/C',11),
														 ('FMT',12),
														 ('FCP',13)

--'FCC',
--'FHP',
--'FCP',
--'FMT',
--'FD', 
--'D',
--'H/C'
go
--drop table rango_horario
create table rango_horario
(
id int not null primary key identity,
hora_entrada char(8) not null,
hora_salida char(8) not null,
unique(hora_entrada,hora_salida)
);
go

insert into rango_horario (hora_entrada, hora_salida) values ('08:00 AM', '10:00 AM'), --1
															 ('08:00 AM', '12:00 PM'), --2
															 ('08:00 AM', '02:00 PM'), --3
															 ('10:00 AM', '12:00 PM'), --4
															 ('10:00 AM', '02:00 PM'), --5
															 ('12:00 PM', '02:00 PM'), --6
															 ('12:00 PM', '04:00 PM'), --7
															 ('02:00 PM', '04:00 PM'), --8
															 ('02:00 PM', '06:00 PM'), --9
															 ('02:00 PM', '08:00 PM'), --10
															 ('04:00 PM', '06:00 PM'), --11
															 ('04:00 PM', '08:00 PM'), --12
															 ('06:00 PM', '08:00 PM'), --13
															 ('06:00 PM', '10:00 PM'), --14
															 ('08:00 PM', '10:00 PM') --15

go
--drop table horario_curso
create table horario_curso
(
id int not null primary key identity,
dia char(2) not null check(dia in ('LU','MA', 'MI', 'JU', 'VI', 'SA')),
id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
id_rango_horario int not null foreign key(id_rango_horario) references rango_horario(id) on delete cascade on update cascade
unique(dia, id_curso, id_rango_horario)
);

go

insert into horario_curso (dia, id_curso, id_rango_horario) values 
												 ('LU', 1, 1),
												 ('LU', 1, 10),
												 ('MA', 1, 1),
												 ('MA', 1, 10),
												 ('MI', 1, 1),
												 ('MI', 1, 10),
												 ('JU', 1, 1),
												 ('JU', 1, 10),
												 ('VI', 1, 1),
												 ('VI', 1, 10),
											

												 ('LU', 2, 1),
												 ('LU', 2, 10),
												 ('MA', 2, 1),
												 ('MA', 2, 10),
												 ('MI', 2, 1),
												 ('MI', 2, 10),
												 ('JU', 2, 1),
												 ('JU', 2, 10),
												 ('VI', 2, 1),
												 ('VI', 2, 10),
												

												 ('LU', 3, 4),
												 ('LU', 3, 8),
												 ('LU', 3, 13),
												 ('MI', 3, 4),
												 ('MI', 3, 8),
												 ('MI', 3, 13),
												 ('VI', 3, 4),
												 ('VI', 3, 8),
												 ('VI', 3, 13),
												 ('SA', 3, 4),
												 ('SA', 3, 8),
												 ('SA', 3, 13),

											
												 ('MI', 4, 4),
												 ('MI', 4, 8),
												 ('MI', 4, 13),
												 ('VI', 4, 4),
												 ('VI', 4, 8),
												 ('VI', 4, 13),
												 ('SA', 4, 4),
												 ('SA', 4, 8),
												 ('SA', 4, 13),

												 ('LU', 5, 2),
												 ('LU', 5, 7),
												 ('MA', 5, 2),
												 ('MA', 5, 7),
												 ('MI', 5, 2),
												 ('MI', 5, 7),											
												 ('JU', 5, 2),
												 ('JU', 5, 7),											
												 ('VI', 5, 2),
												 ('VI', 5, 7),												
												

												 ('LU', 6, 2),
												 ('LU', 6, 7),
												 ('LU', 6, 14),
												 ('MA', 6, 2),
												 ('MA', 6, 7),
												 ('MA', 6, 14),
												 ('VI', 6, 2),
												 ('VI', 6, 7),			
												 ('VI', 6, 14),										
											

												 ('LU', 7, 4),
												 ('LU', 7, 6),
												 ('MA', 7, 4),
												 ('MA', 7, 6),
												 ('JU', 7, 4),
												 ('JU', 7, 6),												
											
												 
												 ('LU', 8, 1),
												 ('LU', 8, 8),
												 ('LU', 8, 13),
												 ('MA', 8, 1),
												 ('MA', 8, 8),
												 ('MA', 8, 13),
												 ('MI', 8, 1),
												 ('MI', 8, 8),
												 ('MI', 8, 13),
												 ('JU', 8, 1),
												 ('JU', 8, 8),
												 ('JU', 8, 13),
												 ('VI', 8, 1),
												 ('VI', 8, 8),
												 ('VI', 8, 13),
											

												 ('LU', 9, 1),
												 ('LU', 9, 10),
												 ('MA', 9, 1),
												 ('MA', 9, 10),
												 ('MI', 9, 1),
												 ('MI', 9, 10),
												 ('JU', 9, 1),
												 ('JU', 9, 10),
												 ('VI', 9, 1),
												 ('VI', 9, 10),

												 ('LU', 10, 4),
												 ('LU', 10, 8),
												 ('LU', 10, 13),
												 ('MI', 10, 4),
												 ('MI', 10, 8),
												 ('VI', 10, 4),
												 ('VI', 10, 8),
												 ('VI', 10, 13),
												 ('SA', 10, 4),
												 ('SA', 10, 8),
												 ('SA', 10, 13),

												 ('LU', 11, 4),
												 ('LU', 11, 8),
												 ('LU', 11, 13),
												 ('MI', 11, 4),
												 ('MI', 11, 8),
												 ('MI', 11, 13),
												 ('VI', 11, 4),
												 ('VI', 11, 8),
												 ('VI', 11, 13),
												 ('SA', 11, 4),
												 ('SA', 11, 8),
												 ('SA', 11, 13),

												 ('LU', 12, 4),
												 ('LU', 12, 6),
												 ('MA', 12, 4),
												 ('MA', 12, 6),
												 ('JU', 12, 4),
												 ('JU', 12, 6),												
												

												 ('LU', 13, 4),
												 ('LU', 13, 6),
												 ('MA', 13, 4),
												 ('MA', 13, 6),
												 ('JU', 13, 4),
												 ('JU', 13, 6);
go

create table estudiante_curso_horario
(
matricula int not null foreign key(matricula) references estudiante(matricula) on delete cascade on update cascade,
id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
id_rango_horario int not null foreign key(id_rango_horario) references rango_horario(id) on delete cascade on update cascade,
primary key(matricula, id_curso, id_rango_horario)
);
go

insert into estudiante_curso_horario (matricula, id_curso, id_rango_horario)
values (1,1,1),
		(1,5,2),
		(2,8,1),
		(3,12,4),
		(4,6,14),
		(5,5,7);
go

--select e.matricula, ei.id_curso, hc.id_rango_horario from estudiante e inner join estudiante_inscripcion ei on e.matricula = ei.matricula
--inner join horario_curso hc on ei.id_curso = hc.id_curso order by e.matricula

go

--create table horario
--(
--id int not null primary key identity,
--dia varchar(10) not null,
--hora_entrada char(8) not null,
--hora_salida char(8) not null,
--unique(dia, hora_entrada, hora_salida)
--);

go
--select * from horario where hora_entrada like '%[0][1-5]:[0-5][0-9] PM%'
--insert into horario (dia, hora_entrada, hora_salida) values ('Lunes','08:00 AM', '10:00 AM'),
--															('Martes','08:00 AM', '10:00 AM'),
--															('Miércoles','08:00 AM', '10:00 AM'),
--															('Jueves','08:00 AM', '10:00 AM'),
--															('Viernes','08:00 AM', '10:00 AM'),
--															('Sábado','08:00 AM', '10:00 AM'),

--															('Lunes','08:00 AM', '12:00 PM'),
--															('Martes','08:00 AM', '12:00 PM'),
--															('Miércoles','08:00 AM', '12:00 PM'),
--															('Jueves','08:00 AM', '12:00 PM'),
--															('Viernes','08:00 AM', '12:00 PM'),
--															('Sábado','08:00 AM', '12:00 PM'),

--															('Lunes','08:00 AM', '02:00 PM'),
--															('Martes','08:00 AM', '02:00 PM'),
--															('Miércoles','08:00 AM', '02:00 PM'),
--															('Jueves','08:00 AM', '02:00 PM'),
--															('Viernes','08:00 AM', '02:00 PM'),
--															('Sábado','08:00 AM', '02:00 PM'),

--															('Lunes','10:00 AM', '12:00 PM'),
--															('Martes','10:00 AM', '12:00 PM'),
--															('Miércoles','10:00 AM', '12:00 PM'),
--															('Jueves','10:00 AM', '12:00 PM'),
--															('Viernes','10:00 AM', '12:00 PM'),
--															('Sábado','10:00 AM', '12:00 PM'),
															
--															('Lunes','10:00 AM', '02:00 PM'),
--															('Martes','10:00 AM', '02:00 PM'),
--															('Miércoles','10:00 AM', '02:00 PM'),
--															('Jueves','10:00 AM', '02:00 PM'),
--															('Viernes','10:00 AM', '02:00 PM'),
--															('Sábado','10:00 AM', '02:00 PM'),

--															('Lunes','12:00 PM', '02:00 PM'),
--															('Martes','12:00 PM', '02:00 PM'),		
--															('Miércoles','12:00 PM', '02:00 PM'),
--															('Jueves','12:00 PM', '02:00 PM'),
--															('Viernes','12:00 PM', '02:00 PM'),
--															('Sábado','12:00 PM', '02:00 PM'),

--															('Lunes','12:00 PM', '04:00 PM'),
--															('Martes','12:00 PM', '04:00 PM'),
--															('Miércoles','12:00 PM', '04:00 PM'),
--															('Jueves','12:00 PM', '04:00 PM'),
--															('Viernes','12:00 PM', '04:00 PM'),
--															('Sábado','12:00 PM', '04:00 PM'),
														
--															('Lunes','02:00 PM', '04:00 PM'),
--															('Martes','02:00 PM', '04:00 PM'),
--															('Miércoles','02:00 PM', '04:00 PM'),
--															('Jueves','02:00 PM', '04:00 PM'),
--															('Viernes','02:00 PM', '04:00 PM'),
--															('Sábado','02:00 PM', '04:00 PM'),
															
--															('Lunes','02:00 PM', '06:00 PM'),
--															('Martes','02:00 PM', '06:00 PM'),
--															('Miércoles','02:00 PM', '06:00 PM'),
--															('Jueves','02:00 PM', '06:00 PM'),
--															('Viernes','02:00 PM', '06:00 PM'),
--															('Sábado','02:00 PM', '06:00 PM'),
															
--															('Lunes','02:00 PM', '08:00 PM'),
--															('Martes','02:00 PM', '08:00 PM'),
--															('Miércoles','02:00 PM', '08:00 PM'),
--															('Jueves','02:00 PM', '08:00 PM'),
--															('Viernes','02:00 PM', '08:00 PM'),
--															('Sábado','02:00 PM', '08:00 PM'),
															
--															('Lunes','04:00 PM', '06:00 PM'),
--															('Martes','04:00 PM', '06:00 PM'),
--															('Miércoles','04:00 PM', '06:00 PM'),
--															('Jueves','04:00 PM', '06:00 PM'),
--															('Viernes','04:00 PM', '06:00 PM'),
--															('Sábado','04:00 PM', '06:00 PM'),
															
--															('Lunes','04:00 PM', '08:00 PM'),
--															('Martes','04:00 PM', '08:00 PM'),
--															('Miércoles','04:00 PM', '08:00 PM'),
--															('Jueves','04:00 PM', '08:00 PM'),
--															('Viernes','04:00 PM', '08:00 PM'),
--															('Sábado','04:00 PM', '08:00 PM'),
																
--															('Lunes','06:00 PM', '08:00 PM'),
--															('Martes','06:00 PM', '08:00 PM'),
--															('Miércoles','06:00 PM', '08:00 PM'),
--															('Jueves','06:00 PM', '08:00 PM'),
--															('Viernes','06:00 PM', '08:00 PM'),
--															('Sábado','06:00 PM', '08:00 PM'),

--															('Lunes','06:00 PM', '10:00 PM'),
--															('Martes','06:00 PM', '10:00 PM'),
--															('Miércoles','06:00 PM', '10:00 PM'),
--															('Jueves','06:00 PM', '10:00 PM'),
--															('Viernes','06:00 PM', '10:00 PM'),
--															('Sábado','06:00 PM', '10:00 PM'),

--															('Lunes','08:00 PM', '10:00 PM'),
--															('Martes','08:00 PM', '10:00 PM'),
--															('Miércoles','08:00 PM', '10:00 PM'),
--															('Jueves','08:00 PM', '10:00 PM'),
--															('Viernes','08:00 PM', '10:00 PM'),																
--															('Sábado','08:00 PM', '10:00 PM');



go
--create table modalidad
--(
--id int not null primary key identity,
--acronimo varchar(3) not null unique,
--descripcion varchar(40) not null unique
--);

--insert into modalidad (acronimo, descripcion) values ('FCC', 'Formación Continua En El Centro'),
--													 ('FHP', 'Formación Habilitación Profesional'),
--													 ('FCP', 'Formación Complementación Profesional'),
--													 ('FMT', 'Formación De Maestros Técnicos'),
--													 ('FD', 'Formación Dual'),
--													 ('D', 'Diplomados'),
--													 ('H/C', 'Formación por itinerario');




go
--drop table estudiante_curso
--create table estudiante_curso
--(
--matricula int not null foreign key(matricula) references estudiante(matricula) on delete cascade on update cascade,
--id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
--primary key(matricula, id_curso)
--);

--go
--insert into estudiante_curso (matricula, id_curso) values
--(1,1),
--(1,2),
--(2,4),
--(2,1),
--(3,1),
--(4,6),
--(4,8),
--(5,7);

--create table estudiante_sede
--(
--matricula int not null foreign key(matricula) references estudiante(matricula) on delete cascade on update cascade,
--id_sede int not null foreign key(id_sede) references sede(id) on delete cascade on update cascade,
--primary key(matricula, id_sede)
--);
--go
--insert into estudiante_sede (matricula, id_sede) values (1,1),
--														(1,4),
--														(2,6),
--														(2,1),
--														(3,1),
--														(4,2),
--														(4,3),
--														(5,2);

--create table estudiante_modulo
--(
--	matricula int not null foreign key(matricula) references estudiante(matricula) on delete cascade on update cascade,
--	id_modulo int not null foreign key(id_modulo) references modulo(id) on delete cascade on update cascade,
--	primary key(matricula, id_modulo)
--);



--insert into estudiante_modulo(matricula, id_modulo) values (1,1),(1,2),
--																  (2,1),(2,2),
--																  (3,1),
--																  (4,2),
--																  (5,3);

go

create table estudiante_inscripcion
(
id int primary key identity,
matricula int not null foreign key(matricula) references estudiante(matricula) on delete cascade on update cascade,
id_sede int not null foreign key(id_sede) references sede(id) on delete cascade on update cascade,
id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
id_modulo int not null foreign key(id_modulo) references modulo(id) on delete cascade on update cascade
--tanda char(1) check (tanda in ('M','T','N')),
--unique(matricula, tanda),
unique(matricula, id_sede, id_curso,id_modulo)
);

--select * from foto_estudiante
go
insert into estudiante_inscripcion (matricula, id_sede, id_curso, id_modulo)
values
(1,1,1,1),
(1,1,1,2),
(1,2,5,3),

(2,3,8,12),
(2,3,8,13),
(3,4,12,10),
(3,4,12,11),

(4,6,6,10),
(4,6,6,11),
(5,5,5,2);
go






--create Procedure sp_informacion_personal_estudiante
--@matricula int,
--@nombre varchar,
--@apellido varchar,
--@cedula varchar,
--@nacionalidad varchar
--as
--select top 1
--matricula AS MATRÍCULA,
--nombre AS NOMBRE,
--apellido AS APELLIDO,
--case when sexo = 'M' then 'Masculino' else 'Femenino' end AS SEXO,
--direccion AS DIRECCIÓN,
--email AS EMAIL,
--cedula AS CÉLULA,
--nacionalidad AS NACIONALIDAD,
--fecha_nacimiento AS 'FECHA NACIMIENTO',
--fecha_ingreso AS 'FECHA INGRESO',
--fecha_salida AS 'FECHA SALIDA',
--case when [status] = 0 then 'Inactivo' else 'Activo' end AS [STATUS],
--tipo_de_sangre AS 'TIPO DE SANGRE',
--enfermedad AS ENFERMEDAD,
--ocupacion AS OCUPACIÓN,
--case when estado_civil = 'S' then 'Solter@'
--else 
--case when estado_civil = 'V' then 'Viud@' 
--else 
--case when estado_civil = 'D' then 'Divorciad@'
--else 'Union Libre' end end end  AS 'ESTADO CIVIL',
--nivel_academico AS 'NIVEL ACADÉMICO' from estudiante 
--where matricula = @matricula or nombre like '%' + @nombre + '%'  or apellido like '%' + @apellido + '%' or cedula = @cedula or nacionalidad like '%' + @nacionalidad + '%';

--exec sp_informacion_personal_estudiante 6, 'klk','klk', 'klk', 'klk'
--select * from horario where hora_entrada like '%[6]:00 PM%' nocturna

--select distinct
--e.matricula AS MATRÍCULA, CONCAT(e.nombre, ' ', e.apellido) 'NOMBRE COMPLETO', h.hora_entrada, h.hora_salida, md.descripcion
--from estudiante_inscripcion ei 
--inner join estudiante e on ei.matricula = e.matricula
--inner join sede s on ei.id_sede = s.id
--inner join curso c on ei.id_curso = c.id
--inner join modulo m on ei.id_modulo = m.id
--inner join modalidad md on ei.id_modalidad = md.id
--inner join horario h on ei.id_horario = h.id
--inner join telefono_estudiante t on e.matricula = t.matricula
--where  t.telefono like '%809%'

--select * from telefono_estudiante 

--select * from estudiante where nombre like '%a%' and apellido like '%ig%'

--select * from horario where hora_entrada like '%[68]:00 PM%'



--select top 1
--e.matricula 
--from estudiante_inscripcion ei 
--inner join estudiante e on ei.matricula = e.matricula
--inner join sede s on ei.id_sede = s.id
--inner join curso c on ei.id_curso = c.id
--inner join modulo m on ei.id_modulo = m.id
--inner join modalidad md on ei.id_modalidad = md.id
--inner join horario h on ei.id_horario = h.id
--inner join telefono_estudiante t on e.matricula = t.matricula
--where e.matricula like '%%' and e.nombre like '%a%'  and e.apellido like '%ig%' 
--and e.cedula like '%%' and e.nacionalidad like '%%' and s.descripcion like '%%' 
--and m.descripcion like '%%' and h.hora_entrada like '%%' and md.descripcion like '%%' 
--and t.telefono like '%%';

--exec sp_matricula_estudiante '1', 'Felix','Caraballo', '40200565584', 'Dominicano', 'Direccion','Des','a','8:00', 'F', '809'
--exec sp_matricula_estudiante '%%', 'Felix','%%', '40200565584', 'Dominicano', 'Direccion','Des','a','8:00', 'F', '809'
--exec sp_matricula_estudiante '%%', '%%','%%', '%%', '%%', '%%','%%','%%','%%', '%%', '%8094216099%'

--create procedure sp_informacion_estudiante
--@matricula int
--as
--select e.matricula, s.descripcion, c.descripcion, m.descripcion, md.descripcion, md.acronimo, h.dia, h.hora_entrada, h.hora_salida
--from estudiante_inscripcion ei 
--inner join estudiante e on ei.matricula = e.matricula
--inner join sede s on ei.id_sede = s.id
--inner join curso c on ei.id_curso = c.id
--inner join modulo m on ei.id_modulo = m.id
--inner join modalidad md on ei.id_modalidad = md.id
--inner join horario h on ei.id_horario = h.id where e.matricula = @matricula;




go
create procedure sp_informacion_estudiante
@matricula int
as
select 
matricula,
nombre,
apellido,
case when sexo = 'M' then 'Masculino'
when sexo = 'F' then 'Femenino' 
else 'No específico' end AS sexo,
direccion,
case when email is null or email = '' then '-----------------' else email end as email,
cedula ,
nacionalidad ,
fecha_nacimiento,
fecha_ingreso,
case when fecha_salida is null or fecha_salida = '' then '--/--/----' else fecha_salida end as fecha_salida,
case when [status] = 0 then 'Inactivo' else 'Activo' end AS [status],
case when tipo_de_sangre = 'N' then 'No específico' else tipo_de_sangre end as tipo_de_sangre,
case when enfermedad is null or enfermedad = '' then '-----------------' else enfermedad end as enfermedad,
ocupacion,
case when estado_civil = 'S' then 'Solter@'
else 
case when estado_civil = 'V' then 'Viud@' 
else 
case when estado_civil = 'D' then 'Divorciad@'
else 'Unión Libre' end end end  AS estado_civil,
nivel_academico from estudiante where matricula = @matricula;
go
exec sp_informacion_estudiante 1
go

select * from estudiante_inscripcion

go
create procedure sp_foto_estudiante
@matricula int
as
select foto from foto_estudiante where matricula = @matricula;

--exec sp_foto_estudiante 6

go

create procedure sp_telefonos_estudiante 
@matricula int
as 
select te.id_tipo_telefono, te.telefono from estudiante e 
inner join telefono_estudiante te on e.matricula= te.matricula 
where e.matricula= @matricula;
go

execute sp_telefonos_estudiante 1
go

--select distinct
--e.matricula AS MATRÍCULA, CONCAT(e.nombre, ' ', e.apellido) 'NOMBRE COMPLETO'
--from estudiante
-------------------------------------------------------------


--select * from curso_sede
----s.descripcion as sede, c.descripcion as curso, 
----m.descripcion as modulo, t.telefono, rh.tanda
--select e.matricula, e.nombre, 
-- c.descripcion as curso
--from estudiante e
--inner join estudiante_modulo em on e.matricula = em.matricula
--inner join modulo_curso mc on em.id_modulo = mc.id_modulo
--inner join curso c on mc.id_curso = c.id
--inner join modulo m on mc.id_modulo = m.id
--inner join curso_sede

IF OBJECT_ID('sp_matricula_nombre_estudiantes', 'P') IS NOT NULL
    DROP PROCEDURE sp_matricula_nombre_estudiantes;
	go
create Procedure sp_matricula_nombre_estudiantes
@matricula varchar(max),
@nombre varchar(max),
@apellido varchar(max),
@cedula varchar(max),
@nacionalidad varchar(max),
@sede varchar(max),
@curso varchar(max),
@modulo varchar(max),
@patronTanda varchar(max),
@modalidad varchar(max),
@telefono varchar(max)
as 
select distinct e.matricula as MATRÍCULA, concat(e.nombre, ' ', e.apellido) as 'NOMBRE COMPLETO' from estudiante e
left join estudiante_inscripcion ei on e.matricula = ei.matricula
left join sede s on ei.id_sede = s.id
left join curso c on ei.id_curso = c.id
left join modulo m on ei.id_modulo = m.id
left join modalidad_curso moc on ei.id_curso = moc.id_curso
left join estudiante_curso_horario ech on ei.matricula = ech.matricula
left join horario_curso hc on ech.id_rango_horario = hc.id_rango_horario
left join rango_horario rh on hc.id_rango_horario = rh.id
left join telefono_estudiante t on e.matricula = t.matricula 
where e.matricula like @matricula  and e.nombre like '%' + @nombre + '%'  
and e.apellido like '%' + @apellido + '%' and e.cedula like '%' + @cedula + '%' 
and e.nacionalidad like '%' + @nacionalidad + '%' and (s.descripcion like '%' + @sede + '%') 
and (c.descripcion like '%' + @curso + '%') and (m.descripcion like '%' + @modulo + '%') 
and (rh.hora_entrada like '%' + @patronTanda + '%') and (moc.modalidad LIKE  @modalidad) 
and (t.telefono like '%' + @telefono + '%');

go
--select * from foto_estudiante
exec sp_matricula_nombre_estudiantes '%6%','%%','%%','%%','%%','%%','%%','%%','%%','%%','%%'
go
--select mc.id_curso,e.matricula, e.nombre, c.descripcion, mc.modalidad from estudiante e inner join estudiante_inscripcion ei on e.matricula = ei.matricula
--	inner join curso c on ei.id_curso = c.id inner join modalidad_curso mc on c.id= mc.id_curso
--	where mc.modalidad = 'FD'
----select * from estudiante
go
create procedure sp_sede_estudiante
@matricula int
as 
select distinct s.id, s.descripcion from estudiante_inscripcion ei 
inner join estudiante e on ei.matricula = e.matricula
inner join sede s on s.id = ei.id_sede where e.matricula = @matricula;

go
create procedure sp_sede_curso_estudiante
@matricula int,
@id_sede int
as 
select distinct c.id, c.descripcion from estudiante_inscripcion ei 
inner join estudiante e on ei.matricula = e.matricula
inner join sede s on s.id = ei.id_sede
inner join curso c on ei.id_curso = c.id where e.matricula = @matricula and s.id = @id_sede;
go

create procedure sp_modalidad
as
select distinct
CASE
        WHEN mc.modalidad = 'FHP' THEN 'Formación habilitación profesional'
        WHEN mc.modalidad = 'FCP' THEN 'Formación complementación profesional'
        WHEN mc.modalidad = 'FCC' THEN 'Formación continua en centro'
        WHEN mc.modalidad = 'FMT' THEN 'Formación de maestros técnicos'
        WHEN mc.modalidad = 'FD' THEN 'Formación dual'
        WHEN mc.modalidad = 'D' THEN 'Diplomados'
        WHEN mc.modalidad = 'H/C' THEN 'Formación por itinerario'
    END AS modalidad  from modalidad_curso mc

	select c.descripcion, mc.modalidad from curso c left join modalidad_curso mc on c.id = mc.id_curso order by c.id desc
	
go
--create procedure sp_modalidad_curso
--as
--select c.descripcion, mc.modalidad from curso c inner join modalidad_curso mc
--on c.id = mc.id_curso;

go

if(OBJECT_ID('sp_rangos_horarios_curso', 'p') is not null)
drop procedure sp_rangos_horarios_curso
go
create procedure sp_rangos_horarios_curso
@id_curso int
as
select distinct rh.id, CONCAT(rh.hora_entrada, ' - ', rh.hora_salida) as rango from horario_curso hc inner join rango_horario rh
on hc.id_rango_horario = rh.id where hc.id_curso = @id_curso order by rh.id;

go

if(OBJECT_ID('sp_dias_rango_horario', 'p') is not null)
drop procedure sp_dias_rango_horario
go
create procedure sp_dias_rango_horario
@id_rango_horario int,
@id_curso int
as
SELECT 
coalesce(LU, 'N/A') AS LUNES,
coalesce(MA, 'N/A') AS MARTES,
coalesce(MI, 'N/A') AS MIÉRCOLES,
coalesce(JU, 'N/A') AS JUEVES,
coalesce(VI, 'N/A') AS VIERNES,
coalesce(SA, 'N/A') AS SÁBADO
FROM
(
    SELECT hc.dia, concat(rh.hora_entrada, ' - ', rh.hora_salida) as rango
    FROM
         horario_curso hc inner join rango_horario rh on hc.id_rango_horario = rh.id
		 where hc.id_curso = @id_curso and rh.id = @id_rango_horario
) AS SourceTable
PIVOT
(
    
  max(rango)  FOR dia in ([LU],[MA],[MI],[JU],[VI],[SA])
) AS p;
go
--select * from horario_curso order by id desc
--select * from rango_horario
create procedure sp_horario_curso
@matricula int,
@id_curso int
as
SELECT 
coalesce(LU, 'N/A') AS LUNES,
coalesce(MA, 'N/A') AS MARTES,
coalesce(MI, 'N/A') AS MIÉRCOLES,
coalesce(JU, 'N/A') AS JUEVES,
coalesce(VI, 'N/A') AS VIERNES,
coalesce(SA, 'N/A') AS SÁBADO
FROM
(
    SELECT hc.dia, concat(rh.hora_entrada, ' - ', rh.hora_salida) as rango
    FROM
         estudiante e inner join estudiante_curso_horario ech on e.matricula = ech.matricula
		inner join horario_curso hc on ech.id_curso = hc.id_curso
		inner join rango_horario rh on ech.id_rango_horario = rh.id and ech.id_rango_horario = hc.id_rango_horario 
		where e.matricula = @matricula and ech.id_curso = @id_curso  
) AS SourceTable
PIVOT
(
    
  max(rango)  FOR dia in ([LU],[MA],[MI],[JU],[VI],[SA])
) AS p;
go


create procedure sp_telefonos
@matricula int
as
select te.telefono from estudiante e 
inner join telefono_estudiante te
on e.matricula = te.matricula where te.matricula = @matricula;

go
create procedure sp_modalidad_curso
@matricula int,
@id_curso int
as 
select distinct 
CASE
        WHEN mc.modalidad = 'FHP' THEN 'Formación habilitación profesional'
        WHEN mc.modalidad = 'FCP' THEN 'Formación complementación profesional'
        WHEN mc.modalidad = 'FCC' THEN 'Formación continua en centro'
        WHEN mc.modalidad = 'FMT' THEN 'Formación de maestros técnicos'
        WHEN mc.modalidad = 'FD' THEN 'Formación dual'
        WHEN mc.modalidad = 'D' THEN 'Diplomados'
        WHEN mc.modalidad = 'H/C' THEN 'Formación por itinerario'
END AS modalidad,
mc.modalidad as acronimo
from estudiante_inscripcion ei 
inner join estudiante e on ei.matricula = e.matricula
inner join modalidad_curso mc on ei.id_curso = mc.id_curso
where e.matricula = @matricula and ei.id_curso = @id_curso;

go

if OBJECT_ID('sp_modulo_curso') is not null
drop procedure sp_modulo_curso
go
create procedure sp_modulo_curso
@matricula int,
@id_curso int
as
select * from estudiante_inscripcion ei 
inner join modulo_curso mc on ei.id_modulo = mc.id_modulo and ei.id_curso = mc.id_curso
inner join modulo m on m.id = ei.id_modulo where ei.matricula = @matricula and ei.id_curso = @id_curso order by ei.id;
go


select * from estudiante_inscripcion
go
create procedure sp_tanda_curso
@matricula int,
@id_curso int
as
select distinct rh.hora_entrada from estudiante e inner join estudiante_curso_horario ech on e.matricula = ech.matricula
inner join horario_curso hc on ech.id_curso = hc.id_curso
inner join rango_horario rh on ech.id_rango_horario = rh.id and ech.id_rango_horario = hc.id_rango_horario 
where e.matricula = @matricula and ech.id_curso = @id_curso;
go
--select * from estudiante_curso_horario
--select * from estudiante_inscripcion

--drop procedure sp_cursos_sede

create procedure sp_cursos_sede
@id_sede int
as
select c.descripcion from sede s 
inner join curso_sede cs on s.id = cs.id_sede
inner join curso c on cs.id_curso = c.id where s.id = @id_sede;
go

--create procedure sp_cursos_no_en_sede
--@id_sede int
--as
--
--select * from curso where id not in (select id_curso from curso_sede cs where id_sede = 6)
--select * from sede

go
--drop procedure sp_cursos_sede

create procedure sp_modulos_curso
@id_curso int
as
select m.descripcion from curso c
inner join modulo_curso mc on c.id = mc.id_curso
inner join modulo m on mc.id_modulo = m.id where c.id = @id_curso;
go

create procedure sp_modulos_curso2
@id_curso int,
@id_modulo int
as
select m.descripcion from curso c
inner join modulo_curso mc on c.id = mc.id_curso
inner join modulo m on mc.id_modulo = m.id where c.id = @id_curso and m.id != @id_modulo;
go

--create procedure sp_verificar_inscripcion
--@matricula int
--as
--select t.cantidad_sede, t.cantidad_curso
--from
--(select 
--matricula, 
--count(distinct id_sede) cantidad_sede,
--count(distinct id_curso) cantidad_curso
--from estudiante_inscripcion group by matricula) t
--where matricula = 6 and (t.cantidad_sede < 2 or t.cantidad_curso < 2)

go

create procedure sp_informacion_estudiante_inscripcion
@matricula int,
@id_curso int
as
select s.descripcion as sede, c.descripcion as curso, m.descripcion as modulo 
from estudiante_inscripcion ei 
inner join sede s on ei.id_sede = s.id
inner join curso c on ei.id_curso = c.id
inner join modulo m on ei.id_modulo = m.id 
where matricula = @matricula and id_curso = @id_curso order by ei.id;

go
create procedure sp_obtener_id_cursos_inscripcion
@matricula int
as
select distinct id_curso as modulo 
from estudiante_inscripcion 
where matricula = @matricula;

go
select * from telefono_estudiante
---------------------------------------------------------------------------------------------------------------------
go
create procedure sp_insertar_estudiante
@nombre varchar(25),
@apellido varchar(25),
@sexo char(1),
@direccion varchar(55),
@email varchar(40),
@cedula char(11),
@nacionalidad varchar(15),
@fecha_nacimiento char(10),
@fecha_ingreso char(10),
@fecha_salida char(10),
@status bit,
@tipo_de_sangre char(2),
@enfermedad varchar(20),
@ocupacion varchar(40),
@estado_civil char(1),
@nivel_academico varchar(25)
AS
insert into estudiante 
(
nombre, apellido, sexo, direccion, email, cedula, nacionalidad, 
fecha_nacimiento, fecha_ingreso, fecha_salida, [status], 
tipo_de_sangre, enfermedad, ocupacion, estado_civil, nivel_academico
)
values
(
@nombre, @apellido, @sexo, @direccion, @email, @cedula, @nacionalidad, 
@fecha_nacimiento, @fecha_ingreso, @fecha_salida, @status,
@tipo_de_sangre,@enfermedad, @ocupacion, @estado_civil, @nivel_academico
);
go


create procedure sp_insertar_actualizar_telefonos_estudiante
@matricula int,
@id_tipo_telefono int,
@telefono char(10)
as
if @telefono not like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
begin
	delete from telefono_estudiante where matricula = @matricula and id_tipo_telefono = @id_tipo_telefono;
end
else
begin
	select * from telefono_estudiante where matricula = @matricula and id_tipo_telefono = @id_tipo_telefono;
	if @@ROWCOUNT = 0
	begin
	  insert into telefono_estudiante (matricula, id_tipo_telefono, telefono) values (@matricula, @id_tipo_telefono, @telefono)
	end
	else
	begin 
		update telefono_estudiante set telefono = @telefono where matricula = @matricula and id_tipo_telefono = @id_tipo_telefono;
	end
end


go
--exec sp_insertar_actualizar_telefonos_estudiante 1, 2, '8094216099'
go
select * from telefono_estudiante


go
create procedure sp_actualizar_estudiante
@matricula int,
@nombre varchar(max),
@apellido varchar(max),
@sexo char(1),
@direccion varchar(max),
@email varchar(max),
@cedula char(11),
@nacionalidad varchar(max),
@fecha_nacimiento char(10),
@fecha_ingreso char(10),
@fecha_salida char(10),
@status bit,
@tipo_de_sangre char(2),
@enfermedad varchar(max),
@ocupacion varchar(max),
@estado_civil char(1),
@nivel_academico varchar(max)
AS
update estudiante 
set nombre = @nombre, apellido = @apellido, sexo = @sexo, direccion = @direccion, email = @email, cedula = @cedula, nacionalidad = @nacionalidad, 
fecha_nacimiento = @fecha_nacimiento, fecha_ingreso = @fecha_ingreso, fecha_salida = @fecha_salida, [status] = @status, tipo_de_sangre = @tipo_de_sangre, 
enfermedad = @enfermedad, ocupacion = @ocupacion, estado_civil = @estado_civil, nivel_academico = @nivel_academico where matricula = @matricula;

if @status = 0
delete from estudiante_inscripcion where matricula = @matricula;

go
select * from estudiante
go

create procedure sp_insertar_telefonos
@matricula int,
@id_tipo_telefono int,
@telefono varchar(max)
as
insert into telefono_estudiante (matricula, id_tipo_telefono, telefono)
values (@matricula, @id_tipo_telefono, @telefono);
go
select * from telefono_estudiante

go

create procedure sp_insertar_actualizar_foto_estudiante
@matricula int, 
@foto image
as
select * from foto_estudiante where matricula = @matricula;
if @@ROWCOUNT = 0
begin
insert into foto_estudiante (matricula, foto) values (@matricula, @foto)
end
else
begin
update foto_estudiante set foto = @foto where matricula = @matricula
end



go
create procedure sp_insertar_inscripcion 
@matricula int,
@id_sede int,
@id_curso int,
@id_modulo int,
@id_rango_horario int
as
select * from estudiante_inscripcion 
where matricula = @matricula and id_sede = @id_sede and id_curso = @id_curso;

insert into estudiante_inscripcion values (@matricula, @id_sede, @id_curso, @id_modulo);
declare @horarioCursoExistente int;
set @horarioCursoExistente = isnull((select matricula from estudiante_curso_horario where matricula = @matricula and id_curso = @id_curso), 0);
if @horarioCursoExistente = 0 
begin
insert into estudiante_curso_horario values (@matricula, @id_curso, @id_rango_horario);
end
update estudiante set [status] = 1 where matricula = @matricula;
go

create procedure sp_actualizar_inscripcion 
@matricula int,
@id_sede int,
@id_sede_act int,
@id_curso int,
@id_curso_act int,
@id_modulo int,
@id_modulo_act int,
@id_rango_horario int,
@id_rango_horario_act int
as
select * from estudiante_inscripcion  ei where matricula = @matricula and id_sede = @id_sede_act and id_curso = @id_curso_act and id_modulo = @id_modulo_act;
if @@ROWCOUNT > 0
begin
delete from estudiante_inscripcion where matricula = @matricula and id_curso = @id_curso_act;
insert into estudiante_inscripcion values (@matricula, @id_sede, @id_curso, @id_modulo);
delete from estudiante_curso_horario where matricula = @matricula and id_curso = @id_curso_act;
insert into estudiante_curso_horario values (@matricula, @id_curso, @id_rango_horario);
	--update estudiante_inscripcion set id_sede = @id_sede, id_curso = @id_curso, id_modulo = @id_modulo
	--where matricula = @matricula and id_sede = @id_sede_act and id_curso = @id_curso_act and id_modulo = @id_modulo_act;
end
else
begin 
	insert into estudiante_inscripcion values (@matricula, @id_sede, @id_curso, @id_modulo);
end

--update estudiante_curso_horario set id_rango_horario = @id_rango_horario, id_curso = @id_curso where matricula = @matricula and id_curso = @id_curso_act;
go



/*select ei.matricula, ei.id_sede, ei.id_curso, ei.id_modulo, s.descripcion,c.descripcion,m.descripcion from estudiante_inscripcion ei 
 inner join sede s on ei.id_sede = s.id inner join curso c on ei.id_curso = c.id inner join modulo m on ei.id_modulo = m.id where ei.matricula = 1
 select * from modulo order by id*/
go
create procedure sp_eliminar_inscripcion
@matricula int, @id_curso int as
delete from estudiante_inscripcion where matricula = @matricula and id_curso = @id_curso;
delete from estudiante_curso_horario where matricula = @matricula and id_curso = @id_curso;
select * from estudiante_inscripcion where matricula = 12
if(@@ROWCOUNT = 0)
begin
update estudiante set [status] = 0 where matricula = @matricula;
end
go
--select * from estudiante_curso_horario
--select * from estudiante_inscripcion
--select * from horario_curso where id_curso = 3
--delete from estudiante_curso_horario where matricula = 6
--delete from estudiante_inscripcion where matricula = 6

--select * from rango_horario order by id

















































































































































--create procedure sp_modulo_curso
--@matricula int,
--@id_sede int,
--@id_curso int,
--@id_modalidad int
--as 
--select distinct m.descripcion from estudiante_inscripcion ei 
--inner join estudiante e on ei.matricula = e.matricula
--inner join sede s on s.id = ei.id_sede
--inner join curso c on ei.id_curso = c.id 
--inner join modalidad md on md.id = ei.id_modalidad
--inner join modulo m on m.id = ei.id_modulo
--where e.matricula = @matricula and s.id = @id_sede and c.id = @id_curso and md.id = @id_modalidad;

--exec sp_modulo_curso 1,1,1,1




--select distinct 
--case when h.dia = 'Lunes' then CONCAT(h.hora_entrada, '-', h.hora_salida) else 'N/A' end LUNES,
--case when h.dia = 'Martes' then CONCAT(h.hora_entrada, '-', h.hora_salida) else 'N/A' end MARTES,  
--case when h.dia = 'Miercoles' then CONCAT(h.hora_entrada, '-', h.hora_salida) else 'N/A' end MIÉRCOLES,
--case when h.dia = 'Jueves' then CONCAT(h.hora_entrada, '-', h.hora_salida) else 'N/A' end JUEVES,
--case when h.dia = 'Viernes' then CONCAT(h.hora_entrada, '-', h.hora_salida) else 'N/A' end VIERNES,
--case when h.dia = 'Sabado' then CONCAT(h.hora_entrada, '-', h.hora_salida) else 'N/A' end SÁBADO
--from estudiante_inscripcion ei 
--inner join estudiante e on ei.matricula = e.matricula
--inner join sede s on s.id = ei.id_sede
--inner join curso c on ei.id_curso = c.id 
--inner join modalidad md on md.id = ei.id_modalidad
--inner join modulo m on m.id = ei.id_modulo
--inner join horario h on h.id = ei.id_horario
--where e.matricula = 1 and s.id = 1 and c.id = 1 and md.id = 1

--create procedure sp_horario_modulo
--@matricula int,
--@id_sede int,
--@id_curso int,
--@id_modalidad int,
--@id_modulo int
--as 
--SELECT 
--coalesce(Lunes, 'N/A') AS LUNES,
--coalesce(Martes, 'N/A') AS MARTES,
--coalesce(Miercoles, 'N/A') AS MIÉRCOLES,
--coalesce(Jueves, 'N/A') AS JUEVES,
--coalesce(Viernes, 'N/A') AS VIERNES,
--coalesce(Sabado, 'N/A') AS SÁBADO
--FROM
--(
--    SELECT dia, concat(hora_entrada, '-', hora_salida) as rango
--    FROM
--        estudiante_inscripcion ei 
--        INNER JOIN estudiante e ON ei.matricula = e.matricula
--        INNER JOIN sede s ON s.id = ei.id_sede
--        INNER JOIN curso c ON ei.id_curso = c.id 
--        INNER JOIN modalidad md ON md.id = ei.id_modalidad
--        INNER JOIN modulo m ON m.id = ei.id_modulo
--        INNER JOIN horario h ON h.id = ei.id_horario
--    where e.matricula = @matricula and s.id = @id_sede and c.id = @id_curso and md.id = @id_modalidad and m.id = @id_modulo
--) AS SourceTable
--PIVOT
--(
    
--  max(rango)  FOR dia in ([Lunes],[Martes],[Miercoles],[Jueves],[Viernes],[Sabado])
--) AS p;

--exec sp_horario_modulo 1,1,1,1,1




--create procedure sp_rangos_horarios
--as
--select * from (select id,concat(hora_entrada,'-', hora_salida) as LUNES from horario where dia = 'Lunes') t1, 
--(select concat(hora_entrada,'-', hora_salida) as MARTES from horario where dia = 'Martes') t2,
--(select concat(hora_entrada,'-', hora_salida) as MIÉRCOLES from horario where dia = 'Miércoles') t3,
--(select concat(hora_entrada,'-', hora_salida) as JUEVES from horario where dia = 'Jueves') t4,
--(select concat(hora_entrada,'-', hora_salida) as VIERNES from horario where dia = 'Viernes') t5,
--(select concat(hora_entrada,'-', hora_salida) as SÁBADO from horario where dia = 'Sábado') t6 
--where t1.LUNES = t2.MARTES and t2.MARTES = t3.MIÉRCOLES AND t3.MIÉRCOLES = t4.JUEVES
--and t4.JUEVES = t5.VIERNES and t5.VIERNES = t6.SÁBADO order by t1.id



--create procedure sp_horarios
--as 
--SELECT
--[Lunes],[Martes],[Miercoles],[Jueves],[Viernes],[Sabado]
--FROM
--(
--    SELECT dia, concat(hora_entrada, '-', hora_salida) as rango
--    FROM horario
   
--) AS SourceTable
--PIVOT
--(
    
--  max(rango)  FOR dia in ([Lunes],[Martes],[Miercoles],[Jueves],[Viernes],[Sabado])
--) AS p;


--SELECT
--    MAX(CASE WHEN dia = 'Lunes' THEN CONCAT(hora_entrada, '-', hora_salida) ELSE '' END) AS LUNES,
--    MAX(CASE WHEN dia = 'Martes' THEN CONCAT(hora_entrada, '-', hora_salida) ELSE '' END) AS MARTES,
--    MAX(CASE WHEN dia = 'Miércoles' THEN CONCAT(hora_entrada, '-', hora_salida) ELSE '' END) AS MIÉRCOLES,
--    MAX(CASE WHEN dia = 'Jueves' THEN CONCAT(hora_entrada, '-', hora_salida) ELSE '' END) AS JUEVES,
--    MAX(CASE WHEN dia = 'Viernes' THEN CONCAT(hora_entrada, '-', hora_salida) ELSE '' END) AS VIERNES,
--    MAX(CASE WHEN dia = 'Sábado' THEN CONCAT(hora_entrada, '-', hora_salida) ELSE '' END) AS SÁBADO
--FROM horario;




--SELECT t.Lunes, t.Martes
--FROM (
--    SELECT
--        (CASE WHEN dia = 'Lunes' THEN hora_entrada ELSE NULL END) AS Lunes,
--        (CASE WHEN dia = 'Martes' THEN hora_entrada ELSE NULL END) AS Martes
--    FROM horario
--    WHERE dia IN ('Lunes', 'Martes')
--) AS t;




--select distinct md.descripcion, md.acronimo from estudiante_inscripcion ei 
--inner join estudiante e on ei.matricula = e.matricula
--inner join sede s on s.id = ei.id_sede
--inner join curso c on ei.id_curso = c.id 
--inner join modalidad md on md.id = ei.id_modalidad
--where e.matricula = 2 and s.id like 1 and c.id = 1;



--create procedure sp_sede_curso_modulo_estudiante
--@matricula int,
--@id_sede int,
--@id_curso int
--as 
--select distinct m.id, m.descripcion, c.descripcion from estudiante_inscripcion ei 
--inner join estudiante e on ei.matricula = e.matricula
--inner join sede s on s.id = ei.id_sede
--inner join curso c on ei.id_curso = c.id 
--inner join modulo m on m.id = ei.id_modulo
--inner join modalidad md on md.id = ei.id_modalidad
--where e.matricula = @matricula and s.id = @id_sede and c.id = @id_curso;



/*create table tanda_estudiante
(
id int not null primary key identity,
matricula int not null foreign key(matricula) references estudiante(matricula) on delete cascade on update cascade,
tanda char(1) check (tanda in ('M','T','N')),
unique(matricula, tanda)
);

insert into tanda_estudiante(matricula,tanda) values (1,'M'),
													(1,'N'),
													(2,'T'),
													(3,'M'),
													(4,'M'),
													(5,'N')*/

/*create table sede_estudiante
(
id int not null primary key identity,
matricula int not null foreign key(matricula) references estudiante(matricula) on delete cascade on update cascade,
id_sede int not null foreign key(id_sede) references sede(id) on delete cascade on update cascade
unique(matricula, id_sede)
);

insert into sede_estudiante (matricula, id_sede) values (1, 1),
                                                        (2, 3),
														(3, 4),
														(1, 2),
														(4, 5),
														(5, 6)*/

/*create table modulo_curso
(
id int not null primary key identity,
id_modulo int not null foreign key(id_modulo) references modulo(id) on delete no action on update cascade,
id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
unique (id_modulo, id_curso)
);

go
create table curso_estudiante
(
id int not null primary key identity,
id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
id_estudiante int not null foreign key(id_estudiante) references estudiante(matricula) on delete cascade on update cascade,
unique (id_curso, id_estudiante)
);*/

/*create table modulo_estudiante
(
id int not null primary key identity,
id_modulo int not null foreign key(id_modulo) references modulo(id) on delete cascade on update cascade,
id_estudiante int not null foreign key(id_estudiante) references estudiante(matricula) on delete cascade on update cascade,
unique (id_modulo, id_estudiante)
);*/

/*create table modulo_horario
(
id int not null primary key identity,
id_horario int not null foreign key(id_horario) references horario(id) on delete cascade on update cascade,
id_modulo int not null foreign key(id_modulo) references modulo(id) on delete cascade on update cascade,
unique(id_horario,id_modulo)
);*/

/*create table modalidad_curso
(
id int not null primary key identity,
id_modalidad int not null foreign key(id_modalidad) references modalidad(id) on delete cascade on update cascade,
id_curso int not null foreign key(id_curso) references curso(id) on delete cascade on update cascade,
unique(id_modalidad, id_curso)

);*/

