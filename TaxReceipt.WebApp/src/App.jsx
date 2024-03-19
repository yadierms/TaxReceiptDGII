import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider,
} from "react-router-dom";

// layouts and pages

import AppLayout from "./layouts/AppLayout";
import ContribuyentePage, {
  contribuyenteLoader,
} from "./pages/ContribuyentePage";
import ComprobantePage, { comprobantesLoader } from "./pages/ComprobantePage";

// router and routes
const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<AppLayout />}>
      <Route
        index
        element={<ContribuyentePage />}
        loader={contribuyenteLoader}
      />
      <Route
        path="contribuyente"
        element={<ContribuyentePage />}
        loader={contribuyenteLoader}
      />
      <Route
        path="comprobante"
        element={<ComprobantePage />}
        loader={comprobantesLoader}
      />
    </Route>
  )
);

function App() {
  return <RouterProvider router={router} />;
}

export default App;
