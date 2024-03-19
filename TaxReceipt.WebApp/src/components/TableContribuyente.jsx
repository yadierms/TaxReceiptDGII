import {
  Box,
  Button,
  Center,
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
import { useState } from "react";
import ModalWithTable from "./ModalWithTable";
import { MdOutlineStickyNote2 } from "react-icons/md";

export default function TableContribuyente({ dataBody }) {
  const [isOpen, setIsOpen] = useState(false);

  const openModal = () => setIsOpen(true);
  const closeModal = () => setIsOpen(false);

  const [selectedData, setSelectedData] = useState([]);
  const handleOpenModal = (data) => {
    openModal();
    setSelectedData(data);
  };

  return (
    <TableContainer alignItems="flex-start" width="100%">
      <Table variant="simple" size="sm">
        {/* <TableCaption>Cantidad de estudiantes</TableCaption> */}
        <Thead>
          <Tr>
            <Th>RNC/Cedula</Th>
            <Th>Nombre</Th>
            <Th>Tipo</Th>
            <Th>Estatus</Th>
            <Th>Opciones</Th>
          </Tr>
        </Thead>
        <Tbody>
          {dataBody.length === 0 ? (
            <div>No hay contribuyentes disponibles.</div>
          ) : (
            dataBody.map((body) => (
              <Tr key={body.rncCedula}>
                <Td>{body.rncCedula}</Td>
                <Td>{body.nombre}</Td>
                <Td>
                  <Box>{body.tipo}</Box>
                </Td>
                <Td>
                  {body.estatus === "activo" ? (
                    <Center
                      bg="green"
                      borderRadius="md"
                      color="white"
                      h="28px"
                      verticalAlign="bottom"
                      py={1.8}
                    >
                      <Text align="center">Activo</Text>
                    </Center>
                  ) : (
                    <Center
                      bg="red"
                      borderRadius="md"
                      color="white"
                      h="28px"
                      verticalAlign="bottom"
                      py={1.8}
                    >
                      <Text align="center">Inactivo</Text>
                    </Center>
                  )}
                </Td>
                <Td>
                  <Button
                    leftIcon={<MdOutlineStickyNote2 />}
                    onClick={() => handleOpenModal(body)}
                    size="sm"
                    colorScheme="blue"
                  >
                    Ver comprobantes
                  </Button>
                  <ModalWithTable
                    isOpen={isOpen}
                    onClose={closeModal}
                    data={selectedData}
                  />
                </Td>
              </Tr>
            ))
          )}
        </Tbody>
        <TableCaption>Total de contribuyentes: {dataBody.length}</TableCaption>
      </Table>
    </TableContainer>
  );
}
