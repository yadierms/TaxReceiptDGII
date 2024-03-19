import {
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalFooter,
  ModalBody,
  ModalCloseButton,
  Button,
  Table,
  Thead,
  Tbody,
  Tr,
  Th,
  Td,
  TableCaption,
  Box,
} from "@chakra-ui/react";
import { useEffect, useState } from "react";
import ApiService from "../services/ApiService";
import sumarITBIS from "../helpers/sumarITBIS.JS";

const ModalWithTable = ({ isOpen, onClose, data }) => {
  const { rncCedula } = data;
  const [comprobantes, setComprobantes] = useState(null);
  const [cargando, setCargando] = useState(false);
  const [totalITBIS, setTotalITBIS] = useState(0);

  useEffect(() => {
    const obtenerComprobante = async () => {
      try {
        setCargando(true);
        const data = await ApiService.obtenerComprobantesPorRnc(rncCedula);
        setComprobantes(data);
        setTotalITBIS(sumarITBIS(data));
      } catch (error) {
        setComprobantes(false);
        setCargando(false);
        console.error("Error al obtener comprobante:", error);
      } finally {
        setCargando(false);
      }
    };

    if (isOpen && rncCedula) {
      obtenerComprobante();
    }
  }, [isOpen, rncCedula]);

  return (
    <Modal isOpen={isOpen} onClose={onClose} size="xl">
      <ModalOverlay />
      <ModalContent>
        <ModalHeader>Comprobantes de {rncCedula}</ModalHeader>
        <ModalCloseButton />
        <ModalBody>
          {cargando ? (
            <div>...Cargando</div>
          ) : comprobantes ? (
            <>
              <Box overflowX="auto">
                <Table variant="simple" overflowX="auto" width="100%">
                  <Thead>
                    <Tr>
                      <Th whiteSpace="nowrap">RNC/Cedula</Th>
                      <Th whiteSpace="nowrap">NFC</Th>
                      <Th whiteSpace="nowrap">Monto</Th>
                      <Th whiteSpace="nowrap">ITBIS</Th>
                    </Tr>
                  </Thead>
                  <Tbody>
                    {comprobantes.map((body) => (
                      <Tr key={body.id}>
                        <Td whiteSpace="nowrap">{body.rncCedula}</Td>
                        <Td whiteSpace="nowrap">{body.ncf}</Td>
                        <Td whiteSpace="nowrap">{body.monto}</Td>
                        <Td whiteSpace="nowrap">{body.itbis18}</Td>
                      </Tr>
                    ))}
                  </Tbody>
                </Table>{" "}
              </Box>
              <TableCaption>
                <Th whiteSpace="nowrap">Total ITBIS</Th>
                <Td
                  overflow="hidden"
                  textOverflow="ellipsis"
                  whiteSpace="nowrap"
                >
                  {totalITBIS}
                </Td>
              </TableCaption>
            </>
          ) : (
            <div>No hay comprobante que mostrar .</div>
          )}
        </ModalBody>

        <ModalFooter>
          <Button colorScheme="blue" mr={3} onClick={onClose}>
            Cerrar
          </Button>
        </ModalFooter>
      </ModalContent>
    </Modal>
  );
};

export default ModalWithTable;
