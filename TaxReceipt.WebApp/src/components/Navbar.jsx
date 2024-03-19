import { Flex, Image } from "@chakra-ui/react";
import logo from "../images/logo.png";

function Navbar() {
  return (
    <Flex as="nav" alignItems="center" h="120px" w="120px">
      <Image boxSize="150px" fit="cover" src={logo} alt="Logo DGII" />
    </Flex>
  );
}
export default Navbar;
