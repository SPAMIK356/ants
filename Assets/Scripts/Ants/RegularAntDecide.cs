using UnityEngine;
[CreateAssetMenu(fileName = "RegularAntLogic", menuName = "Scriptable Objects/Ant Behaviours/RegularAnt")]
public class RegularAntDecide : IDecide
{
    public override Intent Decide(WorldView[] worldViews, Ant ant) 
    {

        float[] weights = new float[worldViews.Length];

        float weightSum = 0;
        if (ant.hasFood)
        {

            for (int i = 0; i < worldViews.Length; i++)
            {
                if (worldViews[i].cellType == CellFlag.Nest) //���� � �����
                {
                    return new Intent(worldViews[i].x, worldViews[i].y, ant, new PutFood()); //�������� ���
                }
                if (!worldViews[i].isPasable)  //���� ������ �����������
                {
                    weights[i] = 0;     //���� ����
                    continue;
                }
                weights[i] = 1 + worldViews[i].homePheromone;
                weightSum += weights[i];
            }
        }
        else
        {
            for (int i = 0; i < worldViews.Length; i++)
            {
                if (worldViews[i].cellType == CellFlag.FoodSource) //���� � ������� ��
                {
                    return new Intent(worldViews[i].x, worldViews[i].y, ant, new GetFood()); //����� ���
                }
                if (!worldViews[i].isPasable)  //���� ������ �����������
                {
                    weights[i] = 0;     //���� ����
                    continue;
                }
                weights[i] = 1 + worldViews[i].foodPheromone;
                weightSum += weights[i];
            }
        }
        float choice = Random.Range(0, weightSum);
        float num = 0;
        for (int i = 0; i < worldViews.Length; i++) 
        { 
            num+= weights[i];
            if (num > choice) return new Intent(worldViews[i].x,worldViews[i].y, ant, new Move());
        }
        return new Intent(ant.x,ant.y,ant, new Idle());
    }

}
