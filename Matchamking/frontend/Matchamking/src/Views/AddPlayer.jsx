import React from 'react'
import BackArrow from '../Components/Atoms/BackArrow'
import TextBox from '../Components/Atoms/TextBox'
import NewPlayerBar from '../Components/Molecules/NewPlayerBar'
import CreatePlayerBtn from '../Components/Atoms/CreatePlayerBtn'
import { useState } from 'react'
import { useEffect } from 'react'

const AddPlayer = () => {

  const [playername, setPlayername] = useState('')
  const [result, setResult] = useState()

  const newPlayerReq = () => {
    if(playername != '')
    {
      fetch('http://localhost:5071/api/players?' + 'name=' + playername, {
        method: 'POST'
      }).then((res) => (res.ok))
    }

  }

  useEffect(() => 
    {},
   [result])
  return (
    <>
      <BackArrow navigate='/'></BackArrow>
      <NewPlayerBar setPlayername={setPlayername}></NewPlayerBar>
      <CreatePlayerBtn onClick={newPlayerReq}></CreatePlayerBtn>
      {
        result === true
      }
      <TextBox text='
      El nickname puede únicamente contener letras, números, 
      ciertos caracteres especiales (-, _, !), y debe tener una longitud
      de 4 a 20 letras.
      El nickname se muestra al momento de ver los rankings,
      estadísticas y pickear jugadores.
      '></TextBox>
    </>
  )
}

export default AddPlayer