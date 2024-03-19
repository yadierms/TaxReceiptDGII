import { Grid, GridItem } from "@chakra-ui/react";
import { Outlet } from "react-router-dom";
import Navbar from "../components/Navbar";

function AppLayout() {
  return (
    <Grid gridTemplateColumns="repeat(5,1fr)">
      <GridItem colSpan="5" as="main">
        <Navbar />
        <Outlet />
      </GridItem>
    </Grid>
  );
}

export default AppLayout;
