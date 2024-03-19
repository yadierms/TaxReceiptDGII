import {
  Box,
  VStack,
  Button,
  Text,
  Flex,
  Input,
  InputGroup,
  InputLeftElement,
  InputRightElement,
} from "@chakra-ui/react";
// import { useLoaderData } from "react-router-dom";
import ApiService from "../services/ApiService";
import { useLoaderData, useNavigate } from "react-router-dom";
// import SearchFilter from "../components/SearchFilter";
import { useState } from "react";
import TableComprobante from "../components/TableComprobante";
import { MdOutlinePeople } from "react-icons/md";

function ComprobantePage() {
  const data = useLoaderData();
  const [searchText, setSearchText] = useState("");

  const filteredData = data.filter((item) =>
    item.rncCedula.toString().includes(searchText.toLowerCase())
  );

  const navigate = useNavigate();

  const handleClick = () => {
    navigate("/contribuyente");
  };

  return (
    <Box boxShadow="xs" rounded="md">
      <VStack spacing="10px">
        <Box w="95%" h={20} paddingTop="10px">
          <Flex justifyContent="flex-start" alignItems="center">
            <Box justifySelf="center" paddingTop="10px">
              <Text as="b" fontSize="xl" textColor="black">
                Listado de comprobantes
              </Text>
            </Box>
            <Box marginLeft="auto" paddingTop="10px">
              <Button
                leftIcon={<MdOutlinePeople />}
                onClick={handleClick}
                colorScheme="blue"
                size="sm"
              >
                Revisar todos los contribuyentes
              </Button>
            </Box>
          </Flex>
        </Box>
        <Box width="95%">
          <Flex justifyContent="flex-start" width="30%">
            <InputGroup>
              <InputLeftElement pointerEvents="none">🔍</InputLeftElement>
              <Input
                placeholder="Buscar por rnc o cedula..."
                value={searchText}
                onChange={(e) => setSearchText(e.target.value)}
              />
              <InputRightElement width="4rem"></InputRightElement>
            </InputGroup>
          </Flex>
        </Box>

        <Box borderRadius={7} p={1} width="100%">
          <TableComprobante dataBody={filteredData} />
        </Box>
      </VStack>
    </Box>
  );
}

export const comprobantesLoader = async () => {
  const data = await ApiService.obtenerComprobantes();

  return data;
};

export default ComprobantePage;
