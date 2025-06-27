USE ProductosDb2


-- Obtener los 5 productos más caros por cada categoría 
SELECT * FROM ( SELECT p.*, ROW_NUMBER() OVER (PARTITION BY p.CategoriaId ORDER BY p.Precio DESC) AS rn
FROM Productos p) AS sub WHERE rn <= 5;

-- Sumar stock agrupado por categoría
SELECT CategoriaId, SUM(Stock) AS StockTotal FROM Productos GROUP BY CategoriaId;

-- Listar productos no vendidos (JOIN con tabla ventas)
SELECT p.* FROM Productos p LEFT JOIN Ventas v ON p.ProductoId = v.ProductoId WHERE v.ProductoId IS NULL;

--Usar un CTE (Common Table Expression) para calcular el promedio de precios y devolver productos cuyo precio lo supere.
WITH PrecioPromedio AS (SELECT AVG(Precio) AS PromedioPrecio FROM Productos)
SELECT p.* FROM Productos p CROSS JOIN PrecioPromedio pp WHERE p.Precio > pp.PromedioPrecio;