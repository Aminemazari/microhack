

import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginSignup from "./pages/LoginSignup";
import HomePage from "./HomePage/homePage";
function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/ia" element={<HomePage/>}/>

      </Routes>
    </BrowserRouter>
  );
}

export default App; 
