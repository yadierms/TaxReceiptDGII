const sumarITBIS = (datos) => {
  // Utilizamos reduce para sumar todos los valores de itbis18
  const totalITBIS = datos.reduce((acumulador, actual) => {
    return acumulador + actual.itbis18;
  }, 0); // Iniciamos el acumulador en 0

  return totalITBIS;
};

export default sumarITBIS;
