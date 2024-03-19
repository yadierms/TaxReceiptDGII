import {
  //   Td,

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
import TableContribuyente from "../components/TableContribuyente";

function ContribuyentePage() {
  const data = useLoaderData();
  const [searchText, setSearchText] = useState("");

  const filteredData = data.filter((item) =>
    item.rncCedula.toString().includes(searchText.toLowerCase())
  );

  const navigate = useNavigate();

  const handleClick = () => {
    navigate("/comprobante");
  };
  return (
    <Box boxShadow="xs" rounded="md">
      <VStack spacing="10px">
        <Box w="95%" h={20} paddingTop="10px">
          <Flex justifyContent="flex-start" alignItems="center">
            <Box justifySelf="center" paddingTop="10px">
              <Text as="b" fontSize="xl" textColor="black">
                Listado de contribuyentes
              </Text>
            </Box>
            <Box marginLeft="auto" paddingTop="10px">
              <Button onClick={handleClick} colorScheme="blue" size="sm">
                Revisar todos los comprobantes
              </Button>
            </Box>
          </Flex>
        </Box>
        <Box width="95%">
          <Flex justifyContent="flex-start" width="30%">
            <InputGroup>
              <InputLeftElement pointerEvents="none">🔍</InputLeftElement>
              <Input
                placeholder="Buscar por nombre..."
                value={searchText}
                onChange={(e) => setSearchText(e.target.value)}
              />
              <InputRightElement width="4rem"></InputRightElement>
            </InputGroup>
          </Flex>
        </Box>

        <Box borderRadius={7} p={1} width="100%">
          <TableContribuyente dataBody={filteredData} />
        </Box>
      </VStack>
    </Box>
  );
}

export const contribuyenteLoader = async () => {
  const data = await ApiService.obtenerContribuyentes();

  return data;
};

export default ContribuyentePage;
