import React from 'react'
import BackArrow from '../Components/Atoms/BackArrow'
import MatchmakingManagement from '../Components/Organisms/MatchmakingManagement'
import { useNavigate } from 'react-router-dom'

const Matchmaking = () => {
  return (
    <>
      <BackArrow navigate={'/'}></BackArrow>
      <MatchmakingManagement/>
    </>
    )
}

export default Matchmaking