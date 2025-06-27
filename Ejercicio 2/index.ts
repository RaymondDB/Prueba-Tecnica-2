// 1️ Función para parsear y marcar como procesado
function parseJsonAndMark(jsonString: string): { [key: string]: any, procesado: boolean } {
  let parsed;
  try {
    parsed = JSON.parse(jsonString);
  } catch (err) {
    throw new Error("JSON inválido");
  }

  return {
    ...parsed,
    procesado: true
  };
}

// 2 Filtrar y ordenar productos
function filtrarYOrdenarProductos(productos: Array<{ nombre: string, stock: number, precio: number }>) {
  return productos
    .filter(p => p.stock > 0)
    .sort((a, b) => b.precio - a.precio);
}

// 3 Simular llamada HTTP (async/await)
async function obtenerProductoSimulado(): Promise<{ nombre: string, precio: number }> {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve({
        nombre: "Producto Simulado",
        precio: 99.99
      });
    }, 2000); 
  });
}

const json = '{"nombre":"Mouse","precio":25}';
const objetoProcesado = parseJsonAndMark(json);
console.log("Objeto procesado:", objetoProcesado);

const lista = [
  { nombre: "A", stock: 0, precio: 50 },
  { nombre: "B", stock: 5, precio: 150 },
  { nombre: "C", stock: 10, precio: 100 },
];

const filtrados = filtrarYOrdenarProductos(lista);
console.log("Filtrados y ordenados:", filtrados);

(async () => {
  const producto = await obtenerProductoSimulado();
  console.log("Producto simulado:", producto);
})();
