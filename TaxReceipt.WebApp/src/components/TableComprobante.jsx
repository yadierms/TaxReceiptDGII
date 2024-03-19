import {
  Box,
  Table,
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
          {dataBody.map((body) => (
            <Tr key={body.id}>
              <Td>{body.rncCedula}</Td>
              <Td>{body.ncf}</Td>
              <Td>
                <Box>{body.monto}</Box>
              </Td>
              <Td>
                <Text>{body.itbis18}</Text>
              </Td>
            </Tr>
          ))}
        </Tbody>
      </Table>
    </TableContainer>
  );
}
