USE tp2_net
--ESPECIALIDADES
CREATE PROCEDURE sp_GetAllUEspecialidades
AS
BEGIN
	SELECT * FROM especialidades
END
--*****
CREATE PROCEDURE sp_GetOneEspecialidad(
@id INT
)
AS
BEGIN
	SELECT * FROM especialidades
	WHERE id_especialidad = @id
END
--*****
CREATE PROCEDURE sp_DeleteEspecialidad(
@id INT
)
AS
BEGIN
	BEGIN TRY
        DELETE FROM especialidades
        WHERE id_especialidad = @id
    END TRY
    BEGIN CATCH
        -- Manejar la excepción y devolver un código de error
        RAISERROR('No se puede eliminar esta especialidad debido a restricciones de clave externa.', 16, 1)
    END CATCH
END
--*****
CREATE PROCEDURE sp_InsertEspecialidad (
    @descripcion VARCHAR(50),
    @notificacion VARCHAR(500) OUTPUT,
    @exito BIT OUTPUT
)
AS
BEGIN
    BEGIN TRY
        IF EXISTS(SELECT 1 FROM especialidades WHERE desc_especialidad = @descripcion)
        BEGIN
            SET @notificacion = 'Ya existe la especialidad ingresada'
            SET @exito = 0
        END
        ELSE
        BEGIN
            INSERT INTO especialidades(desc_especialidad)
            VALUES(@descripcion)
            SET @exito = 1
        END
    END TRY
	BEGIN CATCH
        -- Si se produce un error, establecer el mensaje de notificación adecuado
        SET @notificacion = 'Error al procesar la solicitud';
		SET @exito = 0
    END CATCH
END
--*****
CREATE PROCEDURE sp_UpdateEspecialidad(
@id INT,
@descripcion VARCHAR(50),
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
        IF EXISTS(SELECT 1 FROM especialidades WHERE desc_especialidad = @descripcion AND id_especialidad != @id)
        BEGIN
            SET @notificacion = 'Ya existe la especialidad ingresada'
            SET @exito = 0
        END
        ELSE
        BEGIN
            UPDATE especialidades SET
			desc_especialidad = @descripcion
			WHERE id_especialidad=@id
            SET @exito = 1
        END
    END TRY
	BEGIN CATCH
        -- Si se produce un error, establecer el mensaje de notificación adecuado
        SET @notificacion = 'Error al procesar la solicitud';
		SET @exito = 0
    END CATCH
END
--USUARIOS
CREATE PROCEDURE sp_GetAllUsuarios
AS
BEGIN
	SELECT * FROM usuarios
END
--*****
CREATE PROCEDURE sp_GetOneUsuario(
@id INT
)
AS
BEGIN
	SELECT * FROM usuarios
	WHERE id_usuario = @id
END
--*****
CREATE PROCEDURE sp_DeleteUsuario(
@id INT
)
AS
BEGIN
	DELETE FROM usuarios
	WHERE id_usuario = @id
END
--*****
CREATE PROCEDURE sp_UpdateUsuario
(
@id INT,
@nombre_usuario VARCHAR(50),
@clave VARCHAR(50),
@habilitado BIT,
@nombre VARCHAR(50),
@apellido VARCHAR(50),
@email VARCHAR(50),
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
    BEGIN TRY	
		IF EXISTS (SELECT 1 FROM usuarios WHERE nombre_usuario = @nombre_usuario AND id_usuario != @id) -- Verificar si ya existe un usuario con el nombre de usuario especificado
		BEGIN
			-- Si el nombre de usuario ya existe (excepto para el mismo usuario que se está actualizando), establecer @nombreUsuarioExiste en 1
			SET @notificacion = 'El nombre de usuario ya existe'
            SET @exito = 0
		END
		ELSE
		IF EXISTS (SELECT 1 FROM usuarios WHERE email = @email AND id_usuario != @id)
		BEGIN
			SET @notificacion = 'El email pertenece a otro usuario'
            SET @exito = 0
		END
		ELSE
		BEGIN
			-- Si el nombre de usuario no existe, y el email no existe, actualizar el registro
			UPDATE usuarios SET
				nombre_usuario = @nombre_usuario,
				clave = @clave,
				habilitado = @habilitado,
				nombre = @nombre,
				apellido = @apellido,
				email = @email
			WHERE id_usuario = @id;

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
		SET @exito = 0
	END CATCH
END
--*****
CREATE PROCEDURE sp_InsertUsuario
(
    @nombre_usuario VARCHAR(50),
    @clave VARCHAR(50),
    @habilitado BIT,
    @nombre VARCHAR(50),
    @apellido VARCHAR(50),
    @email VARCHAR(50),
    @id_persona INT,
    @notificacion VARCHAR(500) OUTPUT,
    @exito BIT OUTPUT
)
AS
BEGIN
    BEGIN TRY
        -- Verificar si la persona ya tiene un usuario creado
        IF EXISTS (SELECT 1 FROM usuarios WHERE id_persona = @id_persona)
			BEGIN
				-- Si la persona ya tiene un usuario creado, establecer el mensaje de notificación
				SET @notificacion = 'La persona seleccionada ya tiene un usuario creado';
				SET @exito = 0;
			END
        ELSE
		IF EXISTS (SELECT 1 FROM usuarios WHERE nombre_usuario = @nombre_usuario)
            BEGIN
                -- Si el nombre de usuario ya existe, establecer el mensaje de notificación
                SET @notificacion = 'Nombre de usuario existente';
                SET @exito = 0;
            END
		ELSE
		IF EXISTS (SELECT 1 FROM usuarios WHERE email = @email)
            BEGIN
                -- Si el email ya está registrado, establecer el mensaje de notificación
                SET @notificacion = 'Email ya registrado';
                SET @exito = 0;
			END
        ELSE
        BEGIN
            -- Realizar la inserción de los datos del usuario
            INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email, cambia_clave, id_persona)
            VALUES (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, 0, @id_persona);
                
            -- Establecer el mensaje de notificación para indicar que la inserción se realizó correctamente
            SET @notificacion = 'Usuario creado correctamente';
            SET @exito = 1;
        END
    END TRY
    BEGIN CATCH
        -- Si se produce un error, establecer el mensaje de notificación adecuado
        SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
    END CATCH
END

--*****
CREATE PROCEDURE sp_GetAllPersonas
AS
BEGIN
	SELECT  per.id_persona, per.nombre, per.apellido, per.direccion, per.email, per.telefono, per.fecha_nac, per.legajo, per.tipo_persona, pla.id_plan, pla.desc_plan
	FROM personas per
	INNER JOIN planes pla ON pla.id_plan = per.id_plan
END
--*****
CREATE PROCEDURE sp_GetOnePersona(
@id INT
)
AS
BEGIN
	SELECT * FROM personas
	WHERE id_persona = @id
END
--*****
CREATE PROCEDURE sp_GetOnePersonaForLegajo(
@Legajo INT
)
AS
BEGIN
	SELECT * FROM personas
	WHERE legajo = @Legajo
END
--*****
--PLANES
CREATE PROCEDURE sp_GetAllPlanes
AS
BEGIN
	SELECT p.id_plan, p.desc_plan, e.id_especialidad ,e.desc_especialidad 
	FROM planes p
	INNER JOIN especialidades e ON e.id_especialidad = p.id_especialidad
END
--****
CREATE PROCEDURE sp_GetOnePlan(
@id INT
)
AS
BEGIN
	SELECT *
	FROM planes p
	WHERE id_plan = @id
END
--*****
CREATE PROCEDURE sp_InsertPlan(
@descripcion VARCHAR(50),
@idEspecialidad INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		--IF EXISTS (SELECT 1 FROM planes WHERE desc_plan = @descripcion)
		--	BEGIN
		--		SET @notificacion = 'Ya existe un plan con dicha descripcion';
		--		SET @exito = 0;
		--	END
		--ELSE
		BEGIN
			INSERT INTO planes(desc_plan, id_especialidad)
			VALUES(@descripcion, @idEspecialidad)
			SET @notificacion = 'plan creado correctamente';
            SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_UpdatePlan(
@id INT,
@descripcion VARCHAR(50),
@idEspecialidad INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		--IF EXISTS (SELECT 1 FROM planes WHERE desc_plan = @descripcion)
		--	BEGIN
		--		SET @notificacion = 'Ya existe un plan con dicha descripcion';
		--		SET @exito = 0;
		--	END
		--ELSE
		BEGIN
			UPDATE planes SET
			desc_plan = @descripcion,
			id_especialidad = @idEspecialidad
			WHERE id_plan = @id

			SET @notificacion = 'plan creado correctamente';
            SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_DeletePlan(
@id INT
)
AS
BEGIN
	DELETE FROM planes
	WHERE id_plan = @id
END
--*****
CREATE PROCEDURE sp_DeletePersona(
@id INT
)
AS
BEGIN
	DELETE FROM personas
	WHERE id_persona=@id
END
--*****
CREATE PROCEDURE sp_InsertPersona(
@direccion VARCHAR(50),
@telefono VARCHAR(50),
@fechaNacimiento DATETIME,
@nombre VARCHAR(50),
@apellido VARCHAR(50),
@email VARCHAR(50),
@id_plan INT,
@legajo INT,
@tipoPersona INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM personas WHERE legajo = @legajo)
			BEGIN 
				SET @notificacion = 'Ya existe dicho legajo';
				SET @exito = 0;
			END
		ELSE
		IF EXISTS (SELECT 1 FROM personas WHERE email = @email)
			BEGIN
				SET @notificacion = 'Ya existe dicho email';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			INSERT INTO personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan)
			VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fechaNacimiento, @legajo, @tipoPersona, @id_plan)
			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_UpdatePersona(
@id INT,
@direccion VARCHAR(50),
@telefono VARCHAR(50),
@fechaNacimiento DATETIME,
@nombre VARCHAR(50),
@apellido VARCHAR(50),
@email VARCHAR(50),
@id_plan INT,
@legajo INT,
@tipoPersona INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM personas WHERE legajo = @legajo AND id_persona != @id)
			BEGIN 
				SET @notificacion = 'Ya existe dicho legajo';
				SET @exito = 0;
			END
		ELSE
		IF EXISTS (SELECT 1 FROM personas WHERE email = @email AND id_persona != @id)
			BEGIN 
				SET @notificacion = 'Ya existe dicho email';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			UPDATE personas SET
			nombre = @nombre,
			apellido = @apellido,
			direccion = @direccion,
			email = @email,
			telefono = @telefono,
			fecha_nac = @fechaNacimiento,
			legajo = @legajo,
			tipo_persona = @tipoPersona,
			id_plan = @id_plan
			WHERE id_persona = @id

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_GetAllComisiones
AS
BEGIN
	SELECT c.id_comision, c.anio_especialidad, c.desc_comision, p.id_plan, p.desc_plan
	FROM comisiones c
	INNER JOIN planes p ON c.id_plan = p.id_plan
END
--*****
CREATE PROCEDURE sp_InsertComision(
@descripcion VARCHAR(50),
@anio INT,
@idPlan INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM comisiones WHERE desc_comision=@descripcion AND anio_especialidad = @anio AND id_plan = @idPlan)
			BEGIN 
				SET @notificacion = 'Comision ya registrada';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			INSERT INTO comisiones(desc_comision, anio_especialidad, id_plan)
			VALUES (@descripcion, @anio, @idPlan)

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_GetOneComision(
@id INT
)
AS
BEGIN
	SELECT * FROM comisiones
	WHERE id_comision = @id
END
--*****
CREATE PROCEDURE sp_UpdateComision(
@id INT,
@descripcion VARCHAR(50),
@anio INT,
@idPlan INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM comisiones WHERE desc_comision=@descripcion AND anio_especialidad = @anio AND id_comision != @id)
			BEGIN 
				SET @notificacion = 'Comision ya registrada';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			UPDATE comisiones SET
			desc_comision = @descripcion,
			anio_especialidad = @anio,
			id_plan = @idPlan
			WHERE id_comision = @id

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_DeleteComision(
@id INT
)
AS
BEGIN
	BEGIN TRY
		DELETE FROM comisiones
		WHERE id_comision = @id
	END TRY
	BEGIN CATCH
		
	END CATCH
END
--*****MATERIAS*****
CREATE PROCEDURE sp_GetAllMaterias
AS
BEGIN
	SELECT m.id_materia, m.desc_materia, m.hs_semanales, m.hs_totales, p.id_plan, p.desc_plan
	FROM materias m
	INNER JOIN planes p ON p.id_plan = m.id_plan
END
--*****
CREATE PROCEDURE sp_GetOneMateria(
@id INT
)
AS
BEGIN
	SELECT * FROM materias
	WHERE id_materia = @id
END
--*****
CREATE PROCEDURE sp_InsertMateria(
@descripcion VARCHAR(50),
@hsSemanales INT,
@hsTotales INT,
@idPlan INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM materias WHERE desc_materia = @descripcion AND id_plan = @idPlan)
			BEGIN
				SET @notificacion = 'Materia ya registrada, en efecto puede ingresar la misma materia con distinto plan';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			INSERT INTO materias(desc_materia, hs_semanales, hs_totales, id_plan)
			VALUES(@descripcion, @hsSemanales, @hsTotales, @idPlan)
			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_UpdateMateria(
@id INT,
@descripcion VARCHAR(50),
@hsSemanales INT,
@hsTotales INT,
@idPlan INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM materias WHERE desc_materia = @descripcion AND id_plan = @idPlan AND id_materia != @id)
			BEGIN
				SET @notificacion = 'Materia ya registrada, en efecto puede ingresar la misma materia con distinto plan';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			UPDATE materias SET
			desc_materia = @descripcion,
			hs_semanales = @hsSemanales,
			hs_totales = @hsTotales,
			id_plan = @idPlan
			WHERE id_materia = @id

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_DeleteMateria(
@id INT
)
AS
BEGIN
	BEGIN TRY
		DELETE FROM materias
		WHERE id_materia = @id
	END TRY
	BEGIN CATCH

	END CATCH
END
--*****
CREATE PROCEDURE sp_GetAllCursos
AS
BEGIN
	SELECT c.id_curso, c.descripcion, c.id_materia, c.id_comision, c.anio_calendario, c.cupo, m.desc_materia, com.desc_comision 
	FROM cursos c
	INNER JOIN materias m ON m.id_materia = c.id_materia
	INNER JOIN comisiones com ON com.id_comision = c.id_comision
END
--*****
CREATE PROCEDURE sp_GetAllCursosForPlan(
@idPlan INT
)
AS
BEGIN
	SELECT cur.id_curso, cur.descripcion, cur.id_materia, cur.id_comision, cur.anio_calendario, cur.cupo, mat.desc_materia, com.desc_comision
	FROM cursos cur
	INNER JOIN comisiones com ON com.id_comision = cur.id_comision
	INNER JOIN materias mat ON mat.id_materia = cur.id_materia
	INNER JOIN planes pla ON pla.id_plan = mat.id_plan AND pla.id_plan = com.id_plan
	WHERE pla.id_plan = @idPlan
END
--*****
CREATE PROCEDURE sp_GetOneCurso(
@id INT
)
AS
BEGIN
	SELECT * FROM cursos
	WHERE id_curso = @id
END
--*****
CREATE PROCEDURE sp_DeleteCurso(
@id INT
)
AS
BEGIN
	BEGIN TRY
		DELETE FROM cursos
		WHERE id_curso = @id
	END TRY
	BEGIN CATCH

	END CATCH
END
--*****
CREATE PROCEDURE sp_InsertCurso(
@id_materia INT,
@descripcion VARCHAR(50),
@id_comision INT,
@anio_calendario INT,
@cupo INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM cursos WHERE id_materia = @id_materia AND id_comision = @id_comision AND anio_calendario = @anio_calendario)
			BEGIN
				SET @notificacion = 'Curso ya registrada';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			INSERT INTO cursos(id_materia, id_comision, anio_calendario, cupo, descripcion)
			VALUES(@id_materia, @id_comision, @anio_calendario, @cupo, @descripcion)

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_UpdateCurso(
@id INT,
@descripcion VARCHAR(50),
@id_materia INT,
@id_comision INT,
@anio_calendario INT,
@cupo INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM cursos WHERE id_materia = @id_materia AND id_comision = @id_comision AND anio_calendario = @anio_calendario AND id_curso != @id)
			BEGIN
				SET @notificacion = 'Curso ya registrada';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			UPDATE cursos SET
			id_materia = @id_materia,
			id_comision = @id_comision,
			anio_calendario = @anio_calendario,
			cupo = @cupo,
			descripcion = @descripcion

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_GetAllDocentes(
@tipoPersona INT 
)
AS
BEGIN
	SELECT * FROM personas 
	WHERE tipo_persona = @tipoPersona
END
--*****
CREATE PROCEDURE sp_GetAllDocentesCursos
AS
BEGIN
	SELECT dc.id_dictado, dc.id_curso, dc.id_docente, dc.cargo, c.descripcion, p.legajo
	FROM docentes_cursos dc
	INNER JOIN cursos c ON c.id_curso = dc.id_curso
	INNER JOIN personas p ON p.id_persona = dc.id_docente 
END
--*****
CREATE PROCEDURE sp_GetOneDocenteCurso(
@id INT
)
AS
BEGIN
	SELECT * FROM docentes_cursos
	WHERE id_dictado = @id
END
--*****
CREATE PROCEDURE sp_InsertDocenteCurso(
@id_curso INT,
@id_docente INT,
@cargo INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM docentes_cursos WHERE id_curso = @id_curso AND id_docente = @id_docente)
			BEGIN
				SET @notificacion = 'Docente ya registrado en dicho curso';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			INSERT INTO docentes_cursos(id_curso, id_docente, cargo)
			VALUES(@id_curso, @id_docente, @cargo)

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_UpdateDocenteCurso(
@id INT,
@id_curso INT,
@id_docente INT,
@cargo INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		IF EXISTS (SELECT 1 FROM docentes_cursos WHERE id_curso = @id_curso AND id_docente = @id_docente AND id_dictado != @id)
			BEGIN
				SET @notificacion = 'Docente ya registrado en dicho curso';
				SET @exito = 0;
			END
		ELSE
		BEGIN
			UPDATE docentes_cursos SET
			id_curso = @id_curso,
			id_docente = @id_docente,
			cargo = @cargo
			WHERE id_dictado = @id

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_DeleteDocenteCurso(
@id INT
)
AS
BEGIN
	DELETE FROM docentes_cursos
	WHERE id_dictado = @id
END
--*****
CREATE PROCEDURE sp_GetAllAlumnosInscripciones
AS
BEGIN
	SELECT ai.id_inscripcion, ai.id_alumno, ai.id_curso, ai.condicion, ai.nota, p.legajo, c.descripcion
	FROM alumnos_inscripciones ai
	INNER JOIN personas p ON p.id_persona = ai.id_alumno
	INNER JOIN cursos c  ON c.id_curso = ai.id_curso
	WHERE p.tipo_persona = 2
END
--*****
CREATE PROCEDURE sp_GetAllAlumnosInscripcionesForAlumn(
@id INT
)
AS
BEGIN
	SELECT ai.id_inscripcion, ai.id_alumno, ai.id_curso, ai.condicion, ai.nota, p.legajo, c.descripcion
	FROM alumnos_inscripciones ai
	INNER JOIN personas p ON p.id_persona = ai.id_alumno
	INNER JOIN cursos c  ON c.id_curso = ai.id_curso
	WHERE ai.id_alumno = @id
END
--*****
CREATE PROCEDURE sp_GetOneAlumnoInscripcion(
@id INT
)
AS
BEGIN
	SELECT * FROM alumnos_inscripciones
	WHERE id_inscripcion = @id
END 
--*****
CREATE PROCEDURE sp_InsertAlumnoInscripcion(
@id_alumno INT,
@id_curso INT,
@condicion VARCHAR(50),
@nota INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	DECLARE @cupos_disponibles INT;

        -- Verificar si hay cupos disponibles en el curso
        SELECT @cupos_disponibles = cupo
        FROM cursos
        WHERE id_curso = @id_curso;

        IF @cupos_disponibles > 0
        BEGIN
            -- Verificar si el alumno ya está registrado en el curso
            IF EXISTS (SELECT 1 FROM alumnos_inscripciones WHERE id_curso = @id_curso AND id_alumno = @id_alumno)
            BEGIN
                SET @notificacion = 'Alumno ya registrado a dicho curso';
                SET @exito = 0;
            END
            ELSE
            BEGIN
                -- Insertar la inscripción del alumno en el curso
                INSERT INTO alumnos_inscripciones(id_alumno, id_curso, condicion, nota)
                VALUES(@id_alumno, @id_curso, @condicion, @nota);

                -- Decrementar el número de cupos disponibles
                UPDATE cursos SET cupo = cupo - 1 WHERE id_curso = @id_curso;

                SET @notificacion = 'Inscripción exitosa';
                SET @exito = 1;
            END
        END
        ELSE
        BEGIN
            SET @notificacion = 'No hay cupos disponibles en este curso';
            SET @exito = 0;
        END
    END TRY
    BEGIN CATCH
        SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
    END CATCH
END
--*****
CREATE PROCEDURE sp_UpdateAlumnoInscripcion(
@id INT,
@id_alumno INT,
@id_curso INT,
@condicion VARCHAR(50),
@nota INT,
@notificacion VARCHAR(500) OUTPUT,
@exito BIT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		BEGIN
			UPDATE alumnos_inscripciones SET
			condicion = @condicion,
			nota = @nota
			WHERE id_inscripcion = @id

			SET @exito = 1;
		END
	END TRY
	BEGIN CATCH
		SET @notificacion = 'Error al procesar la solicitud';
        SET @exito = 0;
	END CATCH
END
--*****
CREATE PROCEDURE sp_DeleteAlumnoInscripcion(
@id INT
)
AS
BEGIN
	DELETE FROM alumnos_inscripciones
	WHERE id_inscripcion = @id
END
--*****
CREATE PROCEDURE sp_Loguin(
@nombreUsuario VARCHAR(50),
@password VARCHAR(50)
)
AS
BEGIN
	SELECT * FROM usuarios
	WHERE nombre_usuario = @nombreUsuario AND clave = @password
END
--*****
CREATE PROCEDURE sp_GetAllAlumnosInscripcionesForDocente(
@id INT
)
AS
BEGIN
	SELECT ai.id_inscripcion, ai.id_alumno, ai.id_curso, ai.condicion, ai.nota, p.legajo, c.descripcion
	FROM cursos c
	INNER JOIN docentes_cursos dc ON c.id_curso = dc.id_curso
	INNER JOIN alumnos_inscripciones ai ON ai.id_curso = c.id_curso
	INNER JOIN personas p ON p.id_persona = ai.id_alumno
	WHERE dc.id_docente = @id
END
--*****
CREATE PROCEDURE sp_GetAllForType(
@tipoPersona INT 
)
AS
BEGIN
	SELECT * FROM personas 
	WHERE tipo_persona = @tipoPersona
END