import ResultsContainer from "../Atoms/ResultsContainer";
import React, { useEffect, useState } from 'react'
import HeaderText from "../Atoms/HeaderText";
import styled from "styled-components";
import CriteriaBoxLeaderboard from "../Atoms/CriteriaBoxLeaderboard";
import PlayerLeaderboardBox from "../Atoms/PlayerLeaderboardBox";

const Container = styled.div`
  background-color: white;
  width: 90%;
  height: 70%;
  align-items: center;
  flex-direction: column;
  margin-top: 1rem;
  margin-bottom: 1rem;
  border-radius: 5px;
  max-width: 500px;
  overflow-y: auto;
  max-height: 600px;
`

const Board = () => {
    const [players, setPlayers] = useState([])
    const playersList = [
        {
            position: 1,
            playername: 'Diekkan',
            winrate: '100%',
            played: 12,
            state: 0,
        },
        {
            position: 1,
            playername: 'Emiliardo',
            winrate: '100%',
            played: 12,
            state: 0,
        },
        {
            position: 2,
            playername: 'Goku',
            winrate: '80%',
            played: 12,
            state: -1,
        },
        {
            position: 3,
            playername: 'Seba',
            winrate: '70%',
            played: 12,
            state: 3,
        },
        {
            position: 4,
            playername: 'Nitram',
            winrate: '70%',
            played: 12,
            state: 3,
        },
        {
            position: 5,
            playername: 'Juanma',
            winrate: '70%',
            played: 12,
            state: 3,
        },
        {
            position: 6,
            playername: 'Nachoto',
            winrate: '70%',
            played: 12,
            state: 3,
        },
    ]

    useEffect(() => {
        setPlayers(playersList);
        console.log(playersList)
        }, [])
  return (
    <>
        <HeaderText text='Tabla general'></HeaderText>
        <Container>
            <CriteriaBoxLeaderboard></CriteriaBoxLeaderboard>
            {
                players.map(el => 
                    <PlayerLeaderboardBox 
                    position={el.position}
                    playername={el.playername}
                    winrate={el.winrate}
                    played={el.played}
                    state={el.state}>
                    </PlayerLeaderboardBox>
                )
            }
        </Container>
    </>

  )
}

export default Board