USE tp2_net

INSERT INTO especialidades(desc_especialidad) 
VALUES ('Ing. En sistemas')

INSERT INTO planes(desc_plan, id_especialidad) 
VALUES ('Plan 2008', '')

INSERT INTO personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) 
VALUES ('Elsa', 'Popeludo', 'avenida 01', 'PopeludoElsa@frroUTN.com','3413453455','12/01/80','33333', '3' ,''),
	   ('Tomas', 'Michele', 'Temeto al fondo', 'TomasMiChele@gmail.com', '2473464919', '01/01/1991', '38660', '2', '1')

INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email, cambia_clave, id_persona)
VALUES ('Admin', '123', '1', 'Elsa', 'Popeludo', 'PopeludoElsa@frroUTN.com', '0', '1') --el id de persona lo tengo que poner luego de dar de alta a la persona

SELECT * FROM especialidades
SELECT * FROM personas
SELECT * FROM usuarios
