CREATE OR ALTER FUNCTION udf_TotalVendasCliente (@ID_Cliente INT)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @Total DECIMAL(10,2);
    
    SELECT @Total = ISNULL(SUM(Unidades * Preco_Unidade_Momento), 0)
    FROM dbo.Compra_Produto_Cliente
    WHERE ID_Cliente = @ID_Cliente;
    
    RETURN @Total;
END;