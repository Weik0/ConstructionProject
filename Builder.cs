using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction
{
    public class Builder
    {

        /// <summary>
        /// Рассчитывает количество рулонов обоев для оклейки комнаты.
        /// </summary>
        /// <param name="roomWidth">Ширина комнаты (м).</param>
        /// <param name="roomLength">Длина комнаты (м).</param>
        /// <param name="roomHeight">Высота комнаты (м).</param>
        /// <param name="windowWidth">Ширина окна (м).</param>
        /// <param name="windowHeight">Высота окна (м).</param>
        /// <param name="doorWidth">Ширина дверного проёма (м).</param>
        /// <param name="doorHeight">Высота дверного проёма (м).</param>
        /// <param name="rollWidth">Ширина рулона обоев (0.5 или 1 м).</param>
        /// <returns>Количество рулонов обоев.</returns>
        public int PasteWallpaper(double roomWidth, double roomLength, double roomHeight, double windowWidth, double windowHeight, double doorWidth, double doorHeight, double rollWidth)
        {
            // Площадь стен (периметр * высотa)
            double wallsArea = 2 * (roomWidth + roomLength) * roomHeight;

            // Вычитаем площадь окна и двери
            double windowArea = windowWidth * windowHeight;
            double doorArea = doorWidth * doorHeight;
            double totalAreaToPaste = wallsArea - windowArea - doorArea;

            // Площадь одного рулона (длина рулона * его ширину)
            double rollArea = 10.5 * rollWidth;

            // Рассчитываем необходимое количество рулонов, округляя в большую сторону
            int rollsNeeded = (int)System.Math.Ceiling(totalAreaToPaste / rollArea);
            return rollsNeeded;
        }

        /// <summary>
        /// Рассчитывает количество метров линолеума для комнаты.
        /// </summary>
        /// <param name="roomWidth">Ширина комнаты (м).</param>
        /// <param name="roomLength">Длина комнаты (м).</param>
        /// <param name="linoleumWidth">Ширина рулона линолеума (м).</param>
        /// <returns>Количество метров линолеума.</returns>
        public double LayLinoleum(double roomWidth, double roomLength, double linoleumWidth)
        {
            // Площадь комнаты
            double roomArea = roomWidth * roomLength;

            // Длина линолеума равна длине комнаты
            double linoleumLength = roomLength;

            // определяем количество полос (ширина комнаты / ширину линолеума, округлить вверх) и умножаем на длину комнаты.
            int numberOfStrips = (int)System.Math.Ceiling(roomWidth / linoleumWidth);
            double metersNeeded = numberOfStrips * linoleumLength;

            return metersNeeded;
        }

        /// <summary>
        /// Рассчитывает количество банок краски для покраски потолка.
        /// </summary>
        /// <param name="roomWidth">Ширина комнаты (м).</param>
        /// <param name="roomLength">Длина комнаты (м).</param>
        /// <param name="paintConsumption">Расход краски на 1 кв.м. (л).</param>
        /// <param name="canVolume">Объем одной банки краски (л).</param>
        /// <returns>Количество банок краски.</returns>
        public int CeilingPainting(double roomWidth, double roomLength, double paintConsumption, double canVolume)
        {
            // Площадь потолка
            double ceilingArea = roomWidth * roomLength;

            // Общий необходимый объем краски
            double paintVolumeNeeded = ceilingArea * paintConsumption;

            // Рассчитываем количество банок, округляя в большую сторону
            int cansNeeded = (int)System.Math.Ceiling(paintVolumeNeeded / canVolume);
            return cansNeeded;
        }
    }
}