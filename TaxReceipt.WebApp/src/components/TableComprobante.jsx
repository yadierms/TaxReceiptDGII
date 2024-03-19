import {
  Box,
  Table,
  TableCaption,
  TableContainer,
  Tbody,
  Td,
  Text,
  Th,
  Thead,
  Tr,
} from "@chakra-ui/react";

export default function TableComprobante({ dataBody }) {
  return (
    <TableContainer alignItems="flex-start" width="100%">
      <Table variant="simple" size="sm">
        {/* <TableCaption>Cantidad de estudiantes</TableCaption> */}
        <Thead>
          <Tr>
            <Th>RNC/Cedula</Th>
            <Th>NFC</Th>
            <Th>Monto</Th>
            <Th>ITBIS</Th>
          </Tr>
        </Thead>
        <Tbody>
          {dataBody.length === 0 ? (
            <div>No hay comprobantes disponibles.</div>
          ) : (
            dataBody.map((body) => (
              <Tr key={body.id}>
                <Td>{body.rncCedula}</Td>
                <Td>{body.ncf}</Td>
                <Td>
                  <Box>{body.monto.toFixed(2)}</Box>
                </Td>
                <Td>
                  <Text>{body.itbis18.toFixed(2)}</Text>
                </Td>
              </Tr>
            ))
          )}
        </Tbody>
        <TableCaption>Total de comprobantes: {dataBody.length}</TableCaption>
      </Table>
    </TableContainer>
  );
}
